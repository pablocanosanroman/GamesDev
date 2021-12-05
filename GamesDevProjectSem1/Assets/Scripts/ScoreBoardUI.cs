using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreBoardUI : MonoBehaviour
{
    [SerializeField] private SceneSwitcher m_SceneSwitcher;
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
}
