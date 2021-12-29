using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedBController : MonoBehaviour
{
    private SpeedBoostInteraction m_SpeedBInteract;
    private Rigidbody2D m_RB;
    private Character_Movement m_PlayerMovement;
    [SerializeField] private float m_SpeedBoost;
    [SerializeField] private SoundManager m_SoundManager;

    private void Awake()
    {
        m_RB = GetComponent<Rigidbody2D>();

        m_PlayerMovement = GetComponent<Character_Movement>();
        
    }

    private void Update()
    {

        if (m_SpeedBInteract != null)
        {
            m_SoundManager.Play("SpeedBoost");
            m_PlayerMovement.m_EnableCapVelocity = false;
            m_RB.AddForce(Vector2.right * m_SpeedBoost, ForceMode2D.Impulse);
            StartCoroutine(SpeedBoostTime());

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

    IEnumerator SpeedBoostTime()
    {
        yield return new WaitForSeconds(0.7f);
        m_PlayerMovement.m_EnableCapVelocity = true;
            
    }


}
