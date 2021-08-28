using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour
{

    public GameObject shopPanel;

    private bool lockCursor = true;

   // بعد ما كتبته لاقيت اننا مش محتاجيته اصلااااا تمممااااااامممممم

    void Update()
    {
        // lock cursor bool is true then hide the mouse and lock it
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                lockCursor = false;
                //pause = true;
                shopPanel.SetActive(true);
            }
        }
        else
        {
            //عكس الي فووق
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                lockCursor = true;
                //pause = false;
                shopPanel.SetActive(false);
            }
        }
    }
}
