using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDoorInteraction : MonoBehaviour
{
    private GameObject m_sceneSwitcher;
    private Interaction m_DoorInteract;
    public TypeOfDoor m_DoorSelected;
    

    private void Start()
    {
        m_DoorSelected = TypeOfDoor.NONE;
        m_sceneSwitcher = GameObject.Find("ManagerObject");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            if(m_DoorInteract != null)
            {
                if(DoorSelected(m_DoorInteract.m_DoorType))
                {
                    if(m_DoorSelected == TypeOfDoor.GREEN)
                    {
                        m_sceneSwitcher.GetComponent<SceneSwitcher>().ChangeScene(1);
                        m_DoorInteract = null;
                    }
                    else if(m_DoorSelected == TypeOfDoor.BLUE)
                    {
                        m_sceneSwitcher.GetComponent<SceneSwitcher>().ChangeScene(2);
                        m_DoorInteract = null;
                    }
                    else if(m_DoorSelected == TypeOfDoor.RED)
                    {
                        m_sceneSwitcher.GetComponent<SceneSwitcher>().ChangeScene(3);
                        m_DoorInteract = null;
                    }
                   

                }
                
            }
        }
    }

    public bool DoorSelected(TypeOfDoor doorColor)
    {
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
