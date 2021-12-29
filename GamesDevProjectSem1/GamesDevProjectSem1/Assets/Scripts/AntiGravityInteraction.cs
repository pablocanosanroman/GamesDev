using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravityInteraction : MonoBehaviour
{
    [SerializeField] private Character_Movement m_PlayerMovement;
    public bool m_Collision = false;
    private GameObject[] m_GravityPlatforms;

    private void Awake()
    {
        m_GravityPlatforms = GameObject.FindGameObjectsWithTag("GravityPlatform");
    }

    private void FixedUpdate()
    { 
        if (m_PlayerMovement != null)
        { 
            if (m_Collision)
            {
                foreach(GameObject gravityPlatform in m_GravityPlatforms)
                {
                    gravityPlatform.GetComponent<GravityPlatformInteraction>().m_Collision = false;
                }

                m_PlayerMovement.m_MoreGravityEnabled = false;
                m_PlayerMovement.m_AntiGravityEnabled = true;

                //for (int i = 0; i < m_GravityPlatforms.Length; i++)
                //{
                //    m_GravityPlatforms[i].GetComponent<GravityPlatformInteraction>().m_Collision = false;

                //    if(m_GravityPlatforms[i].GetComponent<GravityPlatformInteraction>().m_Collision == false)
                //    {
                //        m_PlayerMovement.m_MoreGravityEnabled = false;
                //        m_PlayerMovement.m_AntiGravityEnabled = true;
                //    }
                //}
                //m_PlayerMovement.GetComponent<Rigidbody2D>().gravityScale = -5f;
                m_PlayerMovement.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                StartCoroutine(NoCollision());
                StartCoroutine(SetAntiGravityFalse());
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

    IEnumerator NoCollision()
    {
        yield return new WaitForSeconds(1.5f);
        m_Collision = false;
    }

    IEnumerator SetAntiGravityFalse()
    {
        yield return new WaitForSeconds(1.1f);
        m_PlayerMovement.m_AntiGravityEnabled = false;
    }


}
