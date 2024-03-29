using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public Text m_CoinsText;
    public Text m_Timer;
    public Text m_Level;
    public PlayerCoinController m_Coins;
    private int m_CurrentCoins;
    private float m_InitialTime;
    private float m_CurrentTime;
    public int m_Minutes;
    public int m_Seconds;
    public float m_Milliseconds;
    [SerializeField] private GameObject m_WinCanvas;
    [SerializeField] private GameObject m_InGameCanvas;
    [SerializeField] private GameObject m_GameOverCanvas;
    [SerializeField] private GameObject m_PauseCanvas;

    public void Init()
    {
        //Get reference to the text
        m_CoinsText = GetComponent<Text>();
        m_Timer = GetComponent<Text>();
        m_Level = GetComponent<Text>();
        
    }

    private void Start()
    {
        m_InitialTime = Time.time;
    }

    private void Update()
    {
        if (!m_GameOverCanvas.activeInHierarchy || !m_WinCanvas.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                m_PauseCanvas.SetActive(true);
                m_InGameCanvas.SetActive(false);
                Time.timeScale = 0;
            }
        }
        ChangeCoinsText();
        Timer();
    }

    private void ChangeCoinsText()
    {   
        m_CurrentCoins = m_Coins.m_CurrentCoins;

        m_CoinsText.text = ("X" + m_CurrentCoins);
    }

    private void Timer()
    {
        m_CurrentTime = Time.time - m_InitialTime;

        m_Minutes = ((int)m_CurrentTime / 60);
        m_Seconds = ((int)m_CurrentTime % 60);
        m_Milliseconds = ((m_CurrentTime * 100f) % 100f);

        m_Timer.text = m_Minutes.ToString() + ":" + m_Seconds.ToString("00") + ":" + m_Milliseconds.ToString("00");
    }
}

