using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJPController : MonoBehaviour
{
    private JumpPlatformInteraction m_JumpPInteract;
    private Rigidbody2D m_RB;
    [SerializeField] private float m_JumpBoostUp;
    [SerializeField] private float m_JumpBoostRight;

    private void Awake()
    {
        m_RB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(m_JumpPInteract != null)
        {
            m_RB.AddForce(Vector2.up * m_JumpBoostUp, ForceMode2D.Impulse);
            m_RB.AddForce(Vector2.right * m_JumpBoostRight, ForceMode2D.Impulse);
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
