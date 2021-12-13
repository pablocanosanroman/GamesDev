using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravityInteraction : MonoBehaviour
{
    [SerializeField] private Character_Movement m_PlayerMovement;
    public bool m_Collision = false;

    private void FixedUpdate()
    {
        if (m_PlayerMovement != null)
        {
            if (m_Collision)
            {
                m_PlayerMovement.GetComponent<Rigidbody2D>().gravityScale = -5f;
                m_PlayerMovement.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.root.CompareTag("Player"))
        {
            m_Collision = true;
        }
    }
}
