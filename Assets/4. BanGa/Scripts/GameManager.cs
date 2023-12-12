namespace BanGa
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class GameManager : Singleton<GameManager>
    {
        public float spawnTime;
        public int timeLimit;
        public Bird[] birdPrefabs;

        int m_curTimeLimit;
        int m_birdKilled;
        bool m_isOver;

        public int BirdKilled { get => m_birdKilled; set => m_birdKilled = value; }
        public bool IsOver { get => m_isOver; set => m_isOver = value; }

        public override void Awake()
        {
            MakeSingleton(false);
        }
        public override void Start()
        {
            GameGUIManager.Ins.ShowGameGUI(false);
            GameGUIManager.Ins.UpdateKilledCounting(m_birdKilled);
            GameGUIManager.Ins.UpdateReloadFilled(1);
            m_curTimeLimit = timeLimit;
        }

        public void PlayGame()
        {
            StartCoroutine(GameSpawn());

            StartCoroutine(TimeCountDown());
            GameGUIManager.Ins.ShowGameGUI(true);

        }
        IEnumerator GameSpawn()
        {
            while (!m_isOver)
            {
                SpawnBird();
                yield return new WaitForSeconds(spawnTime);
            }
        }

        IEnumerator TimeCountDown()
        {
            while (m_curTimeLimit > 0)
            {
                yield return new WaitForSeconds(1f);
                m_curTimeLimit--;
                GameGUIManager.Ins.UpdateTimer(IntToTime(m_curTimeLimit));
            }
            IsOver = true;

            if (m_birdKilled > Prefs.bestScore)
            {
                GameGUIManager.Ins.gameDialog.UpdateDialog("New best", "Best killed: " + m_birdKilled.ToString());
            }
            else
            {
                GameGUIManager.Ins.gameDialog.UpdateDialog("Your best", "Best killed: " + Prefs.bestScore);
            }
            GameGUIManager.Ins.gameDialog.Show(true);
            GameGUIManager.Ins.CurDialog = GameGUIManager.Ins.gameDialog;
            Prefs.bestScore = m_birdKilled;
            Time.timeScale = 0;
        }


        void SpawnBird()
        {
            Vector3 spawnPos = Vector3.zero;

            int ranCheck = Random.Range(0, 2);

            if (ranCheck == 0)
            {
                spawnPos = new Vector3(-10f, Random.Range(-2f, 3.5f), 0);
            }
            else
            {
                spawnPos = new Vector3(10f, Random.Range(-2f, 3.5f), 0);
            }

            if (birdPrefabs != null && birdPrefabs.Length > 0)
            {
                int ranIdx = Random.Range(0, birdPrefabs.Length);
                if (birdPrefabs[ranIdx])
                {
                    Instantiate(birdPrefabs[ranIdx], spawnPos, Quaternion.identity);
                }
            }
        }

        string IntToTime(int time)
        {
            float minutes = Mathf.Floor(time / 60);
            float seconds = Mathf.RoundToInt(time % 60);
            return minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }
}