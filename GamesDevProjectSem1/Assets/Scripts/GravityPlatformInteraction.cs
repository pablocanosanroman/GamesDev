using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPlatformInteraction : MonoBehaviour
{
    [SerializeField] private Character_Movement m_PlayerMovement;
    public bool m_Collision = false;
    [SerializeField] private AntiGravityInteraction m_AntiGravity;

    private void FixedUpdate()
    {
        if (m_PlayerMovement != null)
        {
            if (m_Collision)
            {
                m_AntiGravity.m_Collision = false;
                m_PlayerMovement.m_AirGravity = false;
                m_PlayerMovement.GetComponent<Rigidbody2D>().gravityScale = 7f;
                m_PlayerMovement.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                StartCoroutine(NoCollision());
                

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.root.CompareTag("Player"))
        {
            m_Collision = true;
        }
    }

    IEnumerator NoCollision()
    {
        yield return new WaitForSeconds(1.5f);
        m_Collision = false;
    }
}
