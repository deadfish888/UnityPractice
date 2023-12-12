namespace Hungbong
{
    using System.Collections;
    using System.Collections.Generic;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.UIElements;

    public class UIManager : MonoBehaviour
    {
        public TextMeshProUGUI scoreText;
        public GameObject gameoverPanel;

        public void SetScoreText(string txt)
        {
            if (scoreText)
            {
                scoreText.text = txt;
            }
        }

        public void SetGameoverPanel(bool isShow)
        {
            if (gameoverPanel)
            {
                gameoverPanel.SetActive(isShow);
            }
        }
    }
}