namespace Hungbong
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Ball : MonoBehaviour
    {
        GameController m_gct;

        private void Start()
        {
            m_gct = FindAnyObjectByType<GameController>();
        }

        private void OnCollisionEnter2D(Collision2D coll)
        {
            if (coll.gameObject.CompareTag("Player"))
            {
                m_gct.IncrementScore();
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("DeathZone"))
            {
                m_gct.SetOver(true);
                Destroy(gameObject);
                Debug.Log("Over...");
            }
        }
    }
}