namespace BanGa
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Bird : MonoBehaviour
    {
        public float xSpeed;
        public float minYSpeed;
        public float maxYSpeed;
        public GameObject deathVfx;

        Rigidbody2D m_rb;
        bool m_isMoveLeftOnStart;
        bool m_isDead;

        private void Awake()
        {
            m_rb = GetComponent<Rigidbody2D>();
        }

        void Start()
        {
            RandomMovingDirection();
        }

        // Update is called once per frame
        void Update()
        {
            m_rb.velocity = new Vector3(
                (m_isMoveLeftOnStart ? -xSpeed : xSpeed), Random.Range(minYSpeed, maxYSpeed));
            Flip();
        }

        void RandomMovingDirection()
        {
            m_isMoveLeftOnStart = transform.position.x > 0 ? true : false;
        }

        void Flip()
        {
            if ((m_isMoveLeftOnStart && transform.localScale.x < 0)
                || (!m_isMoveLeftOnStart && transform.localScale.x > 0)) { return; }
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
        }

        public void Die()
        {
            m_isDead = true;

            GameManager.Ins.BirdKilled++;
            GameGUIManager.Ins.UpdateKilledCounting(GameManager.Ins.BirdKilled);

            Destroy(gameObject);

            if (deathVfx)
            {
                GameObject deathVfxClone = Instantiate(deathVfx, transform.position, Quaternion.identity);
                Destroy(deathVfxClone, 0.5f);
            }


        }
    }
}