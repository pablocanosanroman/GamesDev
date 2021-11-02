using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Character_Movement : MonoBehaviour
{
    private Rigidbody2D m_RB;

    private float m_InitialSpeed = 0.4f;

    private float m_Speed = 0.3f;

   

    private void Start()
    {
        //Gets the attached rigidbody component
        m_RB = GetComponent<Rigidbody2D>();

        Vector2 InitialImpulse = new Vector2(-(transform.position.x * m_InitialSpeed), 0.0f);

        m_RB.AddForce(InitialImpulse, ForceMode2D.Impulse);

    }


    private void Update()
    {
        
    }



}
