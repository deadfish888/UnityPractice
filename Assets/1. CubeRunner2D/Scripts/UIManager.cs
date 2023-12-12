using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public GameObject gameoverPanel;

    // Start is called before the first frame update
    public void SetScoreText(int score)
    {
        if (scoreText != null)
        {
            scoreText.SetText("Score: "+score);
        }
    }

    public void ShowPanel(bool isShow)
    {
        if (gameoverPanel != null)
        {
            gameoverPanel.SetActive(isShow);
        }
    }
}
