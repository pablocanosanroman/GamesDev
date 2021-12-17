using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJPController : MonoBehaviour
{
    private JumpPlatformInteraction m_JumpPInteract;
    private Rigidbody2D m_RB;
    private float m_MaxJump = 18f;
    private bool m_EnableJumpCap;
    [SerializeField] private float m_JumpBoostUp;
    [SerializeField] private float m_JumpBoostRight;

    private void Awake()
    {
        m_RB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        m_EnableJumpCap = false;

        if (m_JumpPInteract != null)
        {
            m_EnableJumpCap = true;
            m_RB.AddForce(Vector2.up * m_JumpBoostUp, ForceMode2D.Impulse);
            m_RB.AddForce(Vector2.right * m_JumpBoostRight, ForceMode2D.Impulse);
            if (m_EnableJumpCap)
            {
                CapJumpVelocity();
                StartCoroutine(CapJumpTime());
            }

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

    public void CapJumpVelocity()
    {
        //Take the minimun between those 2 values, multiply by velocity sign in y
        float CappedXVelocity = m_RB.velocity.x;
        float CappedYVelocity = Mathf.Min(Mathf.Abs(m_RB.velocity.y), m_MaxJump) * Mathf.Sign(m_RB.velocity.y);

        m_RB.velocity = new Vector2(CappedXVelocity, CappedYVelocity);
        
    }

    IEnumerator CapJumpTime()
    {
        yield return new WaitForSeconds(0.2f);
        m_EnableJumpCap = false;
    }

}
