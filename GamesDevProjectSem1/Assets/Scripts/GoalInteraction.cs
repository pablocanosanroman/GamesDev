using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalInteraction : MonoBehaviour
{
    [SerializeField] private GameObject m_InGameCanvas;
    [SerializeField] private GameObject m_WinCanvas;
    public int m_Minutes;
    public int m_Seconds;
    public float m_Milliseconds;
    public string m_Time;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.root.CompareTag("Player"))
        {
            m_Minutes = m_InGameCanvas.GetComponent<InGameUI>().m_Minutes;
            m_Seconds = m_InGameCanvas.GetComponent<InGameUI>().m_Seconds;
            m_Milliseconds = m_InGameCanvas.GetComponent<InGameUI>().m_Milliseconds;
            m_Time = m_Minutes.ToString() + ":" + m_Seconds.ToString("00") + ":" + m_Milliseconds.ToString("00");
            Time.timeScale = 0;
            
            m_InGameCanvas.SetActive(false);
            m_WinCanvas.SetActive(true);

        }
    }
}
