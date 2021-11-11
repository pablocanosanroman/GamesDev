using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interaction : MonoBehaviour
{
    public TypeOfDoor m_DoorType;

    //Check if the character is colliding with the doors or not
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.root.CompareTag("Player"))
        {
            collision.transform.root.GetComponent<PlayerDoorInteraction>().UpdateInteractObject(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.root.CompareTag("Player"))
        {
            collision.transform.root.GetComponent<PlayerDoorInteraction>().UpdateInteractObject(null);
        }
    }
}

public enum TypeOfDoor
{
    NONE = -1,
    GREEN = 0,
    BLUE = 1,
    RED = 2
}
