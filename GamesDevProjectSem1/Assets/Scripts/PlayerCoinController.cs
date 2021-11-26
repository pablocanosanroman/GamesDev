using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoinController : MonoBehaviour
{
    private CoinInteraction m_CoinInteract;
    private Character_Movement m_PlayerMovement;
    private int m_MaxCoins = 10;
    private int m_CurrentCoins;
    private float m_MaxSpeedIncreased = (10f/100f);

    private void Awake()
    {
        m_PlayerMovement = GetComponent<Character_Movement>();
    }

    private void Update()
    {
        if(m_CoinInteract != null)
        {
            Destroy(m_CoinInteract.gameObject);
            m_CurrentCoins++;
            m_PlayerMovement.m_MaxSpeed += m_PlayerMovement.m_MaxSpeed * m_MaxSpeedIncreased;


            if (m_CurrentCoins >= m_MaxCoins)
            {
                m_CurrentCoins = m_MaxCoins;
                
            }

            
        }
    }

    public void UpdateCoinInteractableObject(CoinInteraction coinInteraction)
    {
        m_CoinInteract = coinInteraction;

        if(m_CoinInteract == null)
        {
            m_CoinInteract = coinInteraction;
        }
    }
  
    
}
