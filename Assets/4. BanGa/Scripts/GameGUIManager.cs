namespace BanGa
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEditor.Rendering;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;

    public class GameGUIManager : Singleton<GameGUIManager>
    {
        public GameObject homeGUI;
        public GameObject gameGUI;

        public Dialog gameDialog;
        public Dialog pauseDialog;

        public Image reloadFilled;
        public Text timerText;
        public Text killedCountingText;

        Dialog m_curDialog;

        public Dialog CurDialog { get => m_curDialog; set => m_curDialog = value; }

        public override void Awake()
        {
            MakeSingleton(false);
        }

        public void ShowGameGUI(bool isShow)
        {
            if (gameGUI)
            {
                gameGUI.SetActive(isShow);
            }
            if (homeGUI)
            {
                homeGUI.SetActive(!isShow);
            }
        }

        public void UpdateTimer(string time)
        {
            if (timerText)
            {
                timerText.text = time;
            }
        }

        public void UpdateKilledCounting(int count)
        {
            if (killedCountingText)
            {
                killedCountingText.text = "x" + count.ToString();
            }
        }

        public void UpdateReloadFilled(float rate)
        {
            if (reloadFilled)
            {
                reloadFilled.fillAmount = rate;
            }
        }

        public void PauseGame()
        {
            Time.timeScale = 0f;

            if (pauseDialog)
            {
                pauseDialog.Show(true);
                CurDialog = pauseDialog;
                GameGUIManager.Ins.pauseDialog.UpdateDialog("Pause", "Current killed: " + GameManager.Ins.BirdKilled);
            }
        }

        public void ResumeGame()
        {
            Time.timeScale = 1f;

            if (CurDialog)
            {
                CurDialog.Show(false);
            }
        }

        public void BackToHome()
        {
            ResumeGame();

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void ReplayGame()
        {
            ResumeGame();

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GameManager.Ins.PlayGame();
        }

        public void Exit()
        {
            ResumeGame();

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            Application.Quit();
        }
    }
}