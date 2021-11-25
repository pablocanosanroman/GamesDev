using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedBController : MonoBehaviour
{
    private SpeedBoostInteraction m_SpeedBInteract;
    private Rigidbody2D m_RB;
    private Character_Movement m_PlayerMovement;
    [SerializeField] private float m_SpeedBoost;
    private float m_TimeDelay;

    private void Awake()
    {
        m_RB = GetComponent<Rigidbody2D>();

        m_PlayerMovement = GetComponent<Character_Movement>();
        
    }

    private void Update()
    {

        if (m_SpeedBInteract != null)
        {
            m_PlayerMovement.m_EnableCapVelocity = false;
            m_RB.AddForce(Vector2.right * m_SpeedBoost, ForceMode2D.Impulse);
            m_TimeDelay = 0f;

        }
        else
        {
            m_TimeDelay++;
            if(m_TimeDelay >= 7f)
            {
                m_PlayerMovement.m_EnableCapVelocity = true;
                m_TimeDelay = 0f;
            }
           
        }
        
        
    }

    public void UpdateJPInteractableObject(SpeedBoostInteraction speedBoost)
    {
        m_SpeedBInteract = speedBoost;

        if (m_SpeedBInteract == null)
        {
            m_SpeedBInteract = speedBoost;
        }

    }


}
