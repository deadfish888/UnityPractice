namespace SkyForceRipoff
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Projectile : MonoBehaviour
    {
        public int moveSpeed;

        Rigidbody2D m_rg;

        GameController m_gc;

        AudioSource m_aus;

        public AudioClip crashSound;

        // Start is called before the first frame update
        void Start()
        {
            m_rg = GetComponent<Rigidbody2D>();
            m_gc = FindAnyObjectByType<GameController>();
            m_aus = FindAnyObjectByType<AudioSource>();
            Destroy(gameObject, 2f);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (m_rg)
            {
                m_rg.velocity = Vector3.up * moveSpeed;
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("SceneLimit"))
            {
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Enemy"))
            {
                m_gc.IncrementScore();
                if (m_aus && crashSound)
                {
                    m_aus.PlayOneShot(crashSound);
                }
                Destroy(col.gameObject);
                Destroy(gameObject);
            }
        }
    }
}