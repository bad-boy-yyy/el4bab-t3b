using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{

    public GameObject inventoryPanel;

    public bool inv;
    void Update()
    {
        if (inv)
        {
            inventoryPanel.SetActive(true);
        }else {
            inventoryPanel.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
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

    public void InventoryButton()
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
