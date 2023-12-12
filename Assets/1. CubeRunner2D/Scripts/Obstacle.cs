namespace CubeRunner2D
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Obstacle : MonoBehaviour
    {
        public float moveSpeed;

        GameController m_gc;

        bool isIncrement = false;
        // Start is called before the first frame update
        void Start()
        {
            m_gc = FindAnyObjectByType<GameController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (m_gc.IsOver())
            {
                return;
            }
            transform.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;
            if (transform.position.x <= -8 && !isIncrement)
            {
                m_gc.IncrementScore();
                isIncrement = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("SceneLimit"))
            {
                Debug.Log("Snap!!");
                Destroy(gameObject);
            }
        }
    }
}