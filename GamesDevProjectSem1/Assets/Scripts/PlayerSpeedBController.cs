using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedBController : MonoBehaviour
{
    private SpeedBoostInteraction m_SpeedBInteract;
    private Rigidbody2D m_RB;
    [SerializeField] private float m_SpeedBoost;

    private void Awake()
    {
        m_RB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(m_SpeedBInteract != null)
        {
            m_RB.AddForce(Vector2.right * m_SpeedBoost, ForceMode2D.Impulse);
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
