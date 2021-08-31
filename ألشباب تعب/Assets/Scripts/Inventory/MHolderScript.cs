using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MHolderScript : MonoBehaviour
{

    private GameObject children;

    public bool holding;
    void Update()
    {
        children = GetComponentInChildren<GameObject>();

        if (children != null)
        {
            holding = true;
        }
        else
        {
            holding = false;
        }
    }

}
