using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreBoardUI : MonoBehaviour
{
    [SerializeField] private SceneSwitcher m_SceneSwitcher;
    [SerializeField] private Text m_NameText;
    [SerializeField] private Text m_TimeText;
    [SerializeField] private Transform m_HighScoreHolder;
    [SerializeField] private GameObject m_ScoreboardEntry;
    public void GetToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level" + m_SceneSwitcher.m_CurrentLevel.ToString(), LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public void Load()
    {
        

    }
}
