using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedBController : MonoBehaviour
{
    private SpeedBoostInteraction m_SpeedBInteract;
    private Rigidbody2D m_RB;
    private Character_Movement m_PlayerMovement;
    [SerializeField] private float m_SpeedBoost;

    private void Awake()
    {
        m_RB = GetComponent<Rigidbody2D>();

        m_PlayerMovement = GetComponent<Character_Movement>();
        
    }

    private void FixedUpdate()
    {
        float xPositiveInput = Mathf.Abs(Input.GetAxisRaw("Horizontal"));
        Vector2 force = new Vector2(xPositiveInput, 0f);

        if (m_SpeedBInteract != null)
        {
            m_PlayerMovement.m_EnableCapVelocity = false;
            m_RB.AddForce(force * m_SpeedBoost, ForceMode2D.Impulse);
            
        }
        else
        {
            StartCoroutine(ReEnableCapVelocity());
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

    private IEnumerator ReEnableCapVelocity()
    {
        m_PlayerMovement.m_EnableCapVelocity = true;
        yield return new WaitForSeconds(2.5f);
    }


}
