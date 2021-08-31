using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolderScript : MonoBehaviour
{
    public Transform children;

    public bool holding;
    public bool isMain;

    public int weaponIndex;

    public bool Main1;
    public bool Main2;

    private GunSwitch gunSwitch;

    void Start()
    {
        gunSwitch = GameObject.Find("Player").GetComponent<GunSwitch>();
    }

    void Update()
    {
        if (isMain)
        {
            if (holding)
            {
                if (Main1)
                {
                    gunSwitch.isHolding1 = true;

                    children = GetComponentInChildren<Transform>();

                    weaponIndex = GetComponentInChildren<IButtonScript>().index;

                    gunSwitch.lastW1 = weaponIndex;

                    gunSwitch.lastWO1 = GetComponentInChildren<IButtonScript>().gameObject;
                }
                else if (Main2)
                {
                    gunSwitch.isHolding2 = true;

                    children = GetComponentInChildren<Transform>();

                    weaponIndex = GetComponentInChildren<IButtonScript>().index;

                    gunSwitch.lastW2 = weaponIndex;

                    gunSwitch.lastWO2 = GetComponentInChildren<IButtonScript>().gameObject;
                }
            }
            else
            {
                if (Main1)
                {
                    gunSwitch.isHolding1 = false;

                    weaponIndex = -1;

                    //gunSwitch.lastWO1 = null;
                }
                else if (Main2)
                {
                    gunSwitch.isHolding2 = false;

                    weaponIndex = -1;

                    //gunSwitch.lastWO2 = null;
                }
            }
        }
    }

}
