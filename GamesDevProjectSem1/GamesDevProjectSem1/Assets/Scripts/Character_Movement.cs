﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]

public class Character_Movement : MonoBehaviour
{
    public Rigidbody2D m_RB;

    private Animator m_Animator;

    [SerializeField]
    private float m_Speed;

    [SerializeField]
    private float m_RotationSpeed;

    private float m_JumpForce = 4.3f;

    public float m_MaxSpeed = 10f;

    private Vector3 m_JumpRotation;

    private float m_FlipAngle;

    private int m_FlipCount;

    private bool m_WhatsGrounded;

    public bool m_MoreGravityEnabled;

    public bool m_AntiGravityEnabled;

    private float m_ActionSpeedBoost = 1f;

    public bool m_EnableCapVelocity = true;

    private BoxCollider2D m_PlayerBoxCollider2D;

    private CapsuleCollider2D m_PlayerCapsuleCollider2D;

    [SerializeField] private LayerMask m_GroundLayerMask;

    private RaycastHit2D m_RaycastHit2dBoard;

    private RaycastHit2D m_RaycastHit2dHead;

    //[SerializeField] private GravityPlatformInteraction m_GravityPlatform;
    //[SerializeField] private AntiGravityInteraction m_AntiGravity;


    private void Awake()
    {
        m_RB = GetComponent<Rigidbody2D>();

        m_PlayerBoxCollider2D = transform.GetComponent<BoxCollider2D>();

        m_PlayerCapsuleCollider2D = transform.GetComponent<CapsuleCollider2D>();

        m_Animator = GetComponent<Animator>();
    }
    private void Start()
    {
        m_MoreGravityEnabled = false;
        m_AntiGravityEnabled = false;
    }

    private void Update()
    {
        
        if (gameObject != null)
        {
            if (Input.GetAxisRaw("Horizontal") < 0 && IsGrounded())
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (Input.GetAxisRaw("Horizontal") > 0 && IsGrounded())
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }

            

        }


    }

    private void FixedUpdate()
    {
        if(gameObject != null)
        {
            
            ApplyMovement();

            if (m_EnableCapVelocity)
            {
               CapVelocity();
            }

            if (IsDead())
            {
                Destroy(gameObject);
                SceneManager.LoadScene(5);
            }

            if (transform.position.y < -150)
            {
                Destroy(gameObject);
                SceneManager.LoadScene(5);
            }
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
            m_MoreGravityEnabled = false;
            m_AntiGravityEnabled = false;
            m_RB.gravityScale = 8f;
            m_WhatsGrounded = true;
            SlopeRotationCheck();
            m_RB.AddForce(force, ForceMode2D.Impulse);

            if (Input.GetButton("Jump"))
            {
                m_RB.AddForce(Vector2.up * m_JumpForce, ForceMode2D.Impulse);
                m_Animator.SetBool("IsJumping", true);
            }

            
        }
        else
        {
            m_RB.gravityScale = 1f;

            if (m_MoreGravityEnabled)
            {
                m_RB.gravityScale = 7f;
            }

            if (m_AntiGravityEnabled)
            {
                m_RB.gravityScale = -5f;
            }
            

            m_Animator.SetBool("IsJumping", false);
            Vector3 Rotation = new Vector3(0f, 0f, -RotationForce);

            if (m_WhatsGrounded)
            {
                m_WhatsGrounded = false;
                m_JumpRotation = transform.TransformDirection(Vector3.right);
                m_JumpRotation.z = 0;
                m_FlipCount = 0;
                m_FlipAngle = 0;
                

            }

            if (Input.GetAxis("Horizontal") > 0.1f)
            {
                transform.Rotate(Rotation * Time.fixedDeltaTime);
            }
            else if(Input.GetAxis("Horizontal") < 0.1f)
            {
                transform.Rotate(Rotation * Time.fixedDeltaTime);
            }

            Vector3 facing = transform.TransformDirection(Vector3.right);
            facing.z = 0;

            float angle = Vector3.Angle(m_JumpRotation, facing);
            if (Vector3.Cross(m_JumpRotation, facing).z < 0)
                angle *= -1;

            m_FlipAngle += angle;
            m_JumpRotation = facing;

            if (Mathf.Abs(m_FlipAngle) >= 320)
            {
                m_FlipCount++;
                m_FlipAngle = 0;
            }
        }

        if (m_FlipCount >= 1 && m_WhatsGrounded)
        {
            m_EnableCapVelocity = false;
            m_RB.AddForce(Vector2.right * m_ActionSpeedBoost * m_FlipCount, ForceMode2D.Impulse);
            StartCoroutine(SpeedBoostTime());
            

        }


    }

    public void CapVelocity()
    {
        //Take the minimun between those 2 values, multiply by velocity sign in x
        float CappedXVelocity = Mathf.Min(Mathf.Abs(m_RB.velocity.x), m_MaxSpeed) * Mathf.Sign(m_RB.velocity.x);
        float CappedYVelocity = m_RB.velocity.y;

        m_RB.velocity = new Vector2(CappedXVelocity, CappedYVelocity);
    }

    private void SlopeRotationCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(m_PlayerCapsuleCollider2D.bounds.center, -transform.up, m_PlayerCapsuleCollider2D.bounds.size.y, m_GroundLayerMask);
        transform.up = hit.normal;
    }

    

    private bool IsGrounded()
    {
        m_RaycastHit2dBoard = Physics2D.CapsuleCast(m_PlayerCapsuleCollider2D.bounds.center, m_PlayerCapsuleCollider2D.bounds.size, CapsuleDirection2D.Horizontal, 0f, -transform.up, 0.1f, m_GroundLayerMask);
        return m_RaycastHit2dBoard.collider != null;
        
    }

    private bool IsDead()
    {
        m_RaycastHit2dHead = Physics2D.BoxCast(m_PlayerBoxCollider2D.bounds.center, m_PlayerBoxCollider2D.bounds.size, 0f, transform.up, 0.1f, m_GroundLayerMask);
        return m_RaycastHit2dHead.collider != null;
    }

    IEnumerator SpeedBoostTime()
    {
        yield return new WaitForSeconds(0.5f);
        m_EnableCapVelocity = true;

    }

}