using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinUI : MonoBehaviour
{
    public Text m_PlayerTime;
    public Text m_PlayerHighScore;
    public int m_Minutes;
    public int m_Seconds;
    public float m_Milliseconds;
    [SerializeField] private GameObject m_Goal;
    [SerializeField] private GameObject m_InGameCanvas;
    [SerializeField] private GameObject m_WinCanvas;
    [SerializeField] private GameObject m_NewRecord;
    [SerializeField] private SceneSwitcher m_SceneSwitcher;
    [SerializeField] private SoundManager m_SoundManager;

    private void Start()
    {
        m_PlayerHighScore.text = PlayerPrefs.GetInt("HighScoreMinutes", 100).ToString() + ":" + PlayerPrefs.GetInt("HighScoreSeconds", 59).ToString() + ":" + PlayerPrefs.GetFloat("HighScoreMilliseconds", 99).ToString("00");
    }

    private void Update()
    {
        
        PlayerTime();
        
    }

    private void PlayerTime()
    {
        m_Minutes = m_Goal.GetComponent<GoalInteraction>().m_Minutes;
        m_Seconds = m_Goal.GetComponent<GoalInteraction>().m_Seconds;
        m_Milliseconds = m_Goal.GetComponent<GoalInteraction>().m_Milliseconds;

        m_PlayerTime.text = m_Minutes.ToString() + ":" + m_Seconds.ToString() + ":" + m_Milliseconds.ToString("00");

        if(m_Minutes < PlayerPrefs.GetInt("HighScoreMinutes", 100) || ((m_Seconds < PlayerPrefs.GetInt("HighScoreSeconds", 60)) && m_Minutes == PlayerPrefs.GetInt("HighScoreMinutes")) || 
            ((m_Milliseconds < PlayerPrefs.GetFloat("HighScoreMilliseconds", 100)) && m_Seconds == PlayerPrefs.GetInt("HighScoreSeconds") && m_Minutes == PlayerPrefs.GetInt("HighScoreMinutes")))
        {
            PlayerPrefs.SetInt("HighScoreMinutes", m_Minutes);
            PlayerPrefs.SetInt("HighScoreSeconds", m_Seconds);
            PlayerPrefs.SetFloat("HighScoreMilliseconds", m_Milliseconds);

            m_PlayerHighScore.text = m_Minutes.ToString() + ":" + m_Seconds.ToString() + ":" + m_Milliseconds.ToString("00");

            m_NewRecord.SetActive(true);
            m_SoundManager.Play("NewRecord");
        }
        
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level" + m_SceneSwitcher.m_CurrentLevel.ToString(), LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public void GetToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

}
