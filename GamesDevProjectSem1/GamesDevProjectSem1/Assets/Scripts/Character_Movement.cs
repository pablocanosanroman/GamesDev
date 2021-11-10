using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Character_Movement : MonoBehaviour
{
    private Rigidbody2D m_RB;

    [SerializeField]
    private float m_Speed;

    [SerializeField]
    private float m_RotationSpeed;

    private float m_JumpForce = 5f;

    private float m_MaxSpeed = 10f;

    private bool m_EnableCapVelocity = true;

    private BoxCollider2D boxCollider2D;

    [SerializeField] private LayerMask groundLayerMask;

    

    private void Awake()
    {
        m_RB = GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
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
            m_RB.AddForce(force, ForceMode2D.Impulse);

            Vector2 jumpDirection = new Vector2(0f, Input.GetAxisRaw("Jump"));

            m_RB.AddForce(jumpDirection * m_JumpForce, ForceMode2D.Impulse);
        }
        else
        {

            Vector3 RotationDirection = new Vector3(0f, 0f, RotationForce);
            Vector3 InverseRotation = new Vector3(0f, 0f, -RotationForce);

            if (Input.GetAxis("Horizontal") > 0.1f)
            {
                transform.Rotate(InverseRotation * Time.fixedDeltaTime);
            }
            else if(Input.GetAxis("Horizontal") < 0.1f)
            {
                transform.Rotate(InverseRotation * Time.fixedDeltaTime);

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
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, groundLayerMask);
        return raycastHit2d.collider != null;

    }
   


}
