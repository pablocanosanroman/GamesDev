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
    private string m_Minutes;
    private string m_Seconds;
    private string m_Milliseconds;
    
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

        m_Minutes = ((int)m_CurrentTime / 60).ToString();
        m_Seconds = ((int)m_CurrentTime % 60).ToString("00");
        m_Milliseconds = ((m_CurrentTime * 100f) % 100f).ToString("00");

        m_Timer.text = m_Minutes + ":" + m_Seconds + ":" + m_Milliseconds;
    }
}

