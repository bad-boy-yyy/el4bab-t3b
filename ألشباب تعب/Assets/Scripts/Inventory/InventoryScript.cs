using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{

    public GameObject InventoryPanel;

    public void InventoryButton()
    {
        InventoryPanel.SetActive(true);
    }

}
