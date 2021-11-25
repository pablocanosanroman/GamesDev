using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJPController : MonoBehaviour
{
    private JumpPlatformInteraction m_JumpPInteract;
    private Rigidbody2D m_RB;
    [SerializeField] private float m_JumpBoost;

    private void Awake()
    {
        m_RB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(m_JumpPInteract != null)
        {
            m_RB.AddForce(transform.up * m_JumpBoost, ForceMode2D.Impulse);
        }
    }

    public void UpdateJPInteractableObject(JumpPlatformInteraction jumpPlatform)
    {
        m_JumpPInteract = jumpPlatform;

        if(m_JumpPInteract == null)
        {
            m_JumpPInteract = jumpPlatform;
        }
    }
}
