using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private int m_CurrentLevel = 0;
    [SerializeField] private int m_LastSceneIndex;
   
    
    private void Awake()
    {
        SceneManager.LoadScene("Level" + m_CurrentLevel.ToString(), LoadSceneMode.Single);
    }

    public void ChangeScene(int level)
    {
        SceneManager.UnloadSceneAsync("Level" + m_CurrentLevel.ToString());
        m_CurrentLevel = level;
        m_CurrentLevel %= m_LastSceneIndex;
        SceneManager.LoadScene("Level" + m_CurrentLevel.ToString(), LoadSceneMode.Single);
    }
}
