using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Character_Movement : MonoBehaviour
{
    private Rigidbody2D m_RB;

    private Animator m_Animator;

    [SerializeField]
    private float m_Speed;

    [SerializeField]
    private float m_RotationSpeed;

    private float m_JumpForce = 2f;

    private float m_MaxSpeed = 10f;

    private bool m_EnableCapVelocity = true;

    private BoxCollider2D m_PlayerBoxCollider2D;

    private CapsuleCollider2D m_PlayerCapsuleCollider2D;

    private GameObject m_Ground;

    [SerializeField] private LayerMask groundLayerMask;

    

    private void Awake()
    {
        m_RB = GetComponent<Rigidbody2D>();

        m_PlayerBoxCollider2D = transform.GetComponent<BoxCollider2D>();

        m_PlayerCapsuleCollider2D = transform.GetComponent<CapsuleCollider2D>();

        m_Animator = GetComponent<Animator>();

        m_Ground = new GameObject();
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") < 0 && IsGrounded())
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(Input.GetAxisRaw("Horizontal") > 0 && IsGrounded())
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        
    }

    private void FixedUpdate()
    {
       
        ApplyMovement();

        if (m_EnableCapVelocity)
        {
            CapVelocity();
        }

        

    }

    public void ApplyMovement()
    {
        //Move horizontally
        float xInput = Input.GetAxisRaw("Horizontal");

        float xForce = xInput * m_Speed;

        float RotationForce = xInput * m_RotationSpeed;

        Vector2 force = new Vector2(xForce, 0f);

        //Jump

        if(IsGrounded())
        {
            m_RB.gravityScale = 4f;

            m_RB.AddForce(force, ForceMode2D.Impulse);

            if(Input.GetButton("Jump"))
            {
                m_RB.AddForce(Vector2.up * m_JumpForce, ForceMode2D.Impulse);
                m_Animator.SetBool("IsJumping", true);
            }

           
            
        }
        else
        {
            m_RB.gravityScale = 1f;

            m_Animator.SetBool("IsJumping", false);
            Vector3 Rotation = new Vector3(0f, 0f, -RotationForce);

            if (Input.GetAxis("Horizontal") > 0.1f)
            {
                transform.Rotate(Rotation * Time.fixedDeltaTime);
            }
            else if(Input.GetAxis("Horizontal") < 0.1f)
            {
                transform.Rotate(Rotation * Time.fixedDeltaTime);

            }
        }
        
        
            

    }

    public void CapVelocity()
    {
        //Take the minimun between those 2 values, multiply by velocity sign in x
        float CappedXVelocity = Mathf.Min(Mathf.Abs(m_RB.velocity.x), m_MaxSpeed) * Mathf.Sign(m_RB.velocity.x);
        float CappedYVelocity = m_RB.velocity.y;

        m_RB.velocity = new Vector2(CappedXVelocity, CappedYVelocity);
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.CapsuleCast(m_PlayerCapsuleCollider2D.bounds.center, m_PlayerCapsuleCollider2D.bounds.size, CapsuleDirection2D.Vertical, 0f, Vector2.down, 0.1f, groundLayerMask);
        return raycastHit2d.collider != null;
    }
   


}
