namespace SkyForceRipoff
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using Random = UnityEngine.Random;

    public class GameController : MonoBehaviour
    {
        public GameObject enemy;

        public float spawnTime;

        float m_spawnTime;

        int m_score;

        bool m_isOver;

        UIManager m_ui;

        public int Score { get => m_score; set => m_score = value; }
        public bool IsOver { get => m_isOver; set => m_isOver = value; }

        // Start is called before the first frame update
        void Start()
        {
            m_spawnTime = 0; m_score = 0;
            m_ui = FindAnyObjectByType<UIManager>();
            m_ui.SetScoreText(m_score);
        }

        // Update is called once per frame
        void Update()
        {
            if (m_isOver)
            {
                Time.timeScale = 0;
                m_ui.SetGameoverPanel(m_isOver);
                return;
            }
            m_spawnTime -= Time.deltaTime;
            if (m_spawnTime < 0)
            {
                SpawnEnemy();
                m_spawnTime = spawnTime;
            }
        }

        private void SpawnEnemy()
        {
            float spawnXPos = Random.Range(-10.8f, 9.6f);

            if (enemy)
            {
                Instantiate(enemy, new Vector3(spawnXPos, 6.7f, 0), Quaternion.identity);
            }
        }

        public void IncrementScore()
        {
            if (m_isOver)
            {
                return;
            }
            m_score++;
            m_ui.SetScoreText(m_score);
        }

        public void Replay()
        {
            SceneManager.LoadScene("MainScene");
            m_isOver = false;
            Time.timeScale = 1;
        }
    }
}