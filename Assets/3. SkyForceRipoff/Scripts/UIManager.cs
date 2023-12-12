namespace SkyForceRipoff
{
    using System.Collections;
    using System.Collections.Generic;
    using TMPro;
    using UnityEngine;

    public class UIManager : MonoBehaviour
    {
        public TextMeshProUGUI scoreText;

        public GameObject gameoverPanel;

        public void SetScoreText(int score)
        {
            if (scoreText)
            {
                scoreText.SetText("Score: " + score);
            }
        }

        public void SetGameoverPanel(bool isOver)
        {
            if (gameoverPanel)
            {
                gameoverPanel.SetActive(isOver);
            }
        }
    }
}