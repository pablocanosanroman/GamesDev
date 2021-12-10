using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinUI : MonoBehaviour
{
    public Text m_PlayerTime;
    public Text m_PlayerName;
    [SerializeField] private GameObject m_Goal;
    [SerializeField] private GameObject m_InGameCanvas;
    [SerializeField] private GameObject m_WinCanvas;
    [SerializeField] private GameObject m_ScoreBoardCanvas;

    private void Update()
    {
        PlayerTime();
    }

    private void PlayerTime()
    {
        m_PlayerTime.text = m_Goal.GetComponent<GoalInteraction>().m_Time;
    }

    public void Save()
    {
        m_InGameCanvas.SetActive(false);
        m_WinCanvas.SetActive(false);
        m_ScoreBoardCanvas.SetActive(true);
    }
}
