using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostInteraction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.root.CompareTag("Player"))
        {
            collision.transform.root.GetComponent<PlayerSpeedBController>().UpdateJPInteractableObject(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.root.CompareTag("Player"))
        {
            collision.transform.root.GetComponent<PlayerSpeedBController>().UpdateJPInteractableObject(null);
        }
    }
}
