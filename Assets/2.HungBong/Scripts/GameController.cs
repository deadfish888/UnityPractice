namespace Hungbong
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class GameController : MonoBehaviour
    {
        public GameObject ball;
        public float spawnTime;
        float m_spawnTime;

        int m_score;
        bool m_isOver;

        UIManager m_ui;

        // Start is called before the first frame update
        void Start()
        {
            m_spawnTime = 0;
            m_ui = FindAnyObjectByType<UIManager>();
            m_ui.SetScoreText("Score: 0");
        }

        // Update is called once per frame
        void Update()
        {
            m_spawnTime -= Time.deltaTime;

            if (m_isOver)
            {
                m_spawnTime = 0;
                m_ui.SetGameoverPanel(m_isOver);
                return;
            }

            if (m_spawnTime < 0)
            {
                //if(spawnTime >= 1.2) spawnTime -= (float)0.03;
                SpawnBall();
                m_spawnTime = spawnTime;
            }
        }

        public void SpawnBall()
        {
            Vector2 spawnPos = new Vector2(Random.Range(-10, 10), (float)5.6);

            if (ball)
            {
                Instantiate(ball, spawnPos, Quaternion.identity);
            }
        }

        public void Replay()
        {
            m_score = 0;
            m_isOver = false;
            //spawnTime = 2;
            m_ui.SetScoreText("Score: 0");
            m_ui.SetGameoverPanel(m_isOver);
        }

        public int GetScore()
        {
            return m_score;
        }

        public void SetScore(int value)
        {
            m_score = value;
        }

        public void IncrementScore()
        {
            m_score += 1;
            m_ui.SetScoreText("Score: " + m_score);
        }

        public bool IsOver()
        {
            return m_isOver;
        }

        public void SetOver(bool value)
        {
            m_isOver = value;
        }
    }
}