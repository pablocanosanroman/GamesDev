using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPlatformInteraction : MonoBehaviour
{
    [SerializeField] private Character_Movement m_PlayerMovement;
    public bool m_Collision = false;
    private GameObject[] m_AntiGravityPlatforms;

    private void Awake()
    {
        Debug.Log("Awake");
        m_AntiGravityPlatforms = GameObject.FindGameObjectsWithTag("AntiGravityPlatform");
    }

    private void FixedUpdate()
    {
        if (m_PlayerMovement != null)
        {
            if (m_Collision)
            {
                foreach (GameObject antiGravityPlatform in m_AntiGravityPlatforms)
                {
                    antiGravityPlatform.GetComponent<AntiGravityInteraction>().m_Collision = false;
                }

                m_PlayerMovement.m_MoreGravityEnabled = true;
                m_PlayerMovement.m_AntiGravityEnabled = false;
                //for (int i = 0; i < m_AntiGravityPlatforms.Length; i++)
                //{
                //    m_AntiGravityPlatforms[i].GetComponent<AntiGravityInteraction>().m_Collision = false;

                //    if(m_AntiGravityPlatforms[i].GetComponent<AntiGravityInteraction>().m_Collision == false)
                //    {
                //        m_PlayerMovement.m_AntiGravityEnabled = false;
                //        m_PlayerMovement.m_MoreGravityEnabled = true;
                //    }
                //}
                m_PlayerMovement.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                StartCoroutine(NoCollision());
                StartCoroutine(SetGravityFalse());
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

    IEnumerator SetGravityFalse()
    {
        yield return new WaitForSeconds(1.1f);
        m_PlayerMovement.m_MoreGravityEnabled = false;
    }
}
