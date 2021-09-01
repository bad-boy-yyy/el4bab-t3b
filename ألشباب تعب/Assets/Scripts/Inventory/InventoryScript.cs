using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{

    public GameObject InventoryPanel;

    public void InventoryButton()
    {
<<<<<<< Updated upstream
        InventoryPanel.SetActive(true);
=======
        if (inv)
        {
            inventoryPanel.SetActive(true);
        }
        else
        {
            inventoryPanel.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (inv)
            {
                inv = false;
            }
            else
            {
                inv = true;
            }
        }
>>>>>>> Stashed changes
    }

    public void OpenInventory()
    {
        if (inv)
        {
            inv = false;
        }
        else
        {
            inv = true;
        }
    }
}
