namespace SkyForceRipoff
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Player : MonoBehaviour
    {
        public int moveSpeed;

        public GameObject projectile;

        public Transform shootingPoint;

        GameController m_gc;

        public AudioSource aus;

        public AudioClip shotSound;

        // Start is called before the first frame update
        void Start()
        {
            m_gc = FindAnyObjectByType<GameController>();
        }

        private void Update()
        {

            if (Input.GetKeyDown(KeyCode.Space) && !m_gc.IsOver)
            {
                Shoot();
            }
        }

        void FixedUpdate()
        {
            float xDirection = Input.GetAxisRaw("Horizontal");

            float moveStep = xDirection * Time.deltaTime * moveSpeed;

            if ((transform.position.x <= 9.5 && xDirection > 0)
                || (transform.position.x >= -10.8 && xDirection < 0))
            {
                transform.position += new Vector3(moveStep, 0, 0);
            }

        }

        void Shoot()
        {
            if (projectile && shootingPoint)
            {
                Instantiate(projectile, shootingPoint.position, Quaternion.identity);
            }
            if (aus && shotSound)
            {
                aus.PlayOneShot(shotSound);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                m_gc.IsOver = true;
                Debug.Log("Over...");
            }
        }
    }
}