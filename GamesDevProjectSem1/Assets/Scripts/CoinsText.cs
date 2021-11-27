using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsText : MonoBehaviour
{
    public Text m_Text;
    public PlayerCoinController m_Coins;
    private int m_CurrentCoins;

    
    public void Init()
    {
        //Get reference to the text
        m_Text = GetComponent<Text>();
        
    }

    private void Update()
    {
        
        ChangeText();
    }

    private void ChangeText()
    {   
        m_CurrentCoins = m_Coins.m_CurrentCoins;

        m_Text.text = ("X" + m_CurrentCoins);
    }
}

