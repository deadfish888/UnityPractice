using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public GameObject obstacle;

    public AudioSource aus;

    public float spawnTime;

    float m_spawnTime;

    int m_score;

    bool m_isOver=false;

    UIManager m_ui;

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
            m_ui.ShowPanel(m_isOver);
            Time.timeScale = 0;
            return;
        }
        m_spawnTime -= Time.deltaTime;
        if(m_spawnTime <= 0)
        {
            SpawnObstacle();
            m_spawnTime = spawnTime;
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("Gameplay");
        m_isOver = false;
        Time.timeScale = 1;
    }

    private void SpawnObstacle()
    {
        Vector3 spawnPos = new Vector3(13f, Random.Range(-2.5f, -1.2f));

        if (obstacle)
        {
            Instantiate(obstacle, spawnPos, Quaternion.identity);
        }
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
        if (m_isOver)
        {
            return;
        }
        m_score++;
        m_ui.SetScoreText(m_score);
    }

    public float GetSpawnTime()
    {
        return m_spawnTime;
    }

    public void SetSpawnTime(float value)
    {
        m_spawnTime = value;
    }

    public bool IsOver() { return m_isOver; }
    public void SetOver(bool value) {  m_isOver = value; }
}
