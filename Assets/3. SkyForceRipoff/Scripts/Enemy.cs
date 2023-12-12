namespace SkyForceRipoff
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Enemy : MonoBehaviour
    {
        public int speed;

        Rigidbody2D m_rb;

        GameController m_gc;

        // Start is called before the first frame update
        void Start()
        {
            m_rb = GetComponent<Rigidbody2D>();
            m_gc = FindAnyObjectByType<GameController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (m_rb != null)
            {
                m_rb.velocity = Vector3.down * speed;
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("DeathZone"))
            {
                m_gc.IsOver = true;
                Destroy(gameObject);
            }
        }
    }
}