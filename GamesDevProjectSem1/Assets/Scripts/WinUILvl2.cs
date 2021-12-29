using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinUILvl2 : MonoBehaviour
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

    private void Start()
    {
        m_PlayerHighScore.text = PlayerPrefs.GetInt("HighScoreMinutesLvl2", 100).ToString() + ":" + PlayerPrefs.GetInt("HighScoreSecondsLvl2", 59).ToString() + ":" + PlayerPrefs.GetFloat("HighScoreMillisecondsLvl2", 99).ToString("00");
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

        if (m_Minutes < PlayerPrefs.GetInt("HighScoreMinutesLvl2", 100) || ((m_Seconds < PlayerPrefs.GetInt("HighScoreSecondsLvl2", 60)) && m_Minutes == PlayerPrefs.GetInt("HighScoreMinutesLvl2")) ||
            ((m_Milliseconds < PlayerPrefs.GetFloat("HighScoreMillisecondsLvl2", 100)) && m_Seconds == PlayerPrefs.GetInt("HighScoreSecondsLvl2") && m_Minutes == PlayerPrefs.GetInt("HighScoreMinutesLvl2")))
        {
            PlayerPrefs.SetInt("HighScoreMinutesLvl2", m_Minutes);
            PlayerPrefs.SetInt("HighScoreSecondsLvl2", m_Seconds);
            PlayerPrefs.SetFloat("HighScoreMillisecondsLvl2", m_Milliseconds);

            m_PlayerHighScore.text = m_Minutes.ToString() + ":" + m_Seconds.ToString() + ":" + m_Milliseconds.ToString("00");

            m_NewRecord.SetActive(true);
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
