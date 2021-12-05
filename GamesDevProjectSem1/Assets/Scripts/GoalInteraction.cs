using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalInteraction : MonoBehaviour
{
    [SerializeField] private GameObject m_InGameCanvas;
    [SerializeField] private GameObject m_WinCanvas;
    [SerializeField] private GameObject m_ScoreBoardCanvas;
    public string m_Time;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.root.CompareTag("Player"))
        {
            m_Time = m_InGameCanvas.GetComponent<InGameUI>().m_Timer.text;
            Time.timeScale = 0;
            m_InGameCanvas.SetActive(false);
            m_ScoreBoardCanvas.SetActive(false);
            m_WinCanvas.SetActive(true);

        }
    }
}
