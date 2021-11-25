using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinInteraction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.root.CompareTag("Player"))
        {
            collision.transform.root.GetComponent<PlayerCoinController>().UpdateCoinInteractableObject(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.root.CompareTag("Player"))
        {
            collision.transform.root.GetComponent<PlayerCoinController>().UpdateCoinInteractableObject(null);
            
        }
    }
}
