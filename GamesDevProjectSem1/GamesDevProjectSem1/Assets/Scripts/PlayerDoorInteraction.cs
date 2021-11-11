using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDoorInteraction : MonoBehaviour
{
    public SceneSwitcher m_sceneSwitcher;
    private Interaction m_DoorInteract;
    public TypeOfDoor m_DoorSelected;
    

    private void Start()
    {
        m_DoorSelected = TypeOfDoor.NONE;
       
       
    }

    private void Update()
    {
        //If W is pressed and the character is triggering the door, change the scene
        if(Input.GetKeyDown(KeyCode.W))
        {
            if(m_DoorInteract != null)
            {
                if(DoorSelected(m_DoorInteract.m_DoorType))
                {
                    
                    if (m_DoorInteract.m_DoorType == TypeOfDoor.GREEN)
                    {
                        m_sceneSwitcher.ChangeScene(1);

                    }
                    else if (m_DoorInteract.m_DoorType == TypeOfDoor.BLUE)
                    {
                        m_sceneSwitcher.ChangeScene(2);

                    }
                    else if (m_DoorInteract.m_DoorType == TypeOfDoor.RED)
                    {
                        m_sceneSwitcher.ChangeScene(3);

                    }


                }
                
            }
        }
    }

    public bool DoorSelected(TypeOfDoor doorColor)
    {
        //Set the door color to the one the character is colliding with
        if(m_DoorSelected != doorColor)
        {
            m_DoorSelected = doorColor;
            return true;
        }

        return false;
    }

    public void UpdateInteractObject(Interaction door)
    {

        m_DoorInteract = door;
        
        if(m_DoorInteract == null)
        {
            m_DoorInteract = door;
        }
    }
}
