using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void GetToStart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);

    }

    public void Exit()
    {
        Application.Quit();
    }
}

