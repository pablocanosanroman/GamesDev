using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    
    public int m_CurrentLevel = 1;
    [SerializeField] private int m_LastSceneIndex;

    //Changes the screen into a new one
    public void ChangeScene(int level)
    {
        if(m_CurrentLevel != 1)
        {
            SceneManager.UnloadSceneAsync("Level" + m_CurrentLevel.ToString());
        }
        
        m_CurrentLevel = level;
        m_CurrentLevel %= m_LastSceneIndex;
        SceneManager.LoadScene("Level" + m_CurrentLevel.ToString(), LoadSceneMode.Single);
    }
}
