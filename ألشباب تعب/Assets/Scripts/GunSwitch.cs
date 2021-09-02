using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitch : MonoBehaviour
{
    public GameObject[] Weapons;

    public GameObject Holder1;
    public GameObject Holder2;

    [HideInInspector]public bool isHolding1;
    [HideInInspector]public bool isHolding2;

    public int lastW1;
    public int lastW2;

    public GameObject lastWO1;
    public GameObject lastWO2;

    void Update()
    {
        if (isHolding1)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                GetFirstWeapon();
            }
        }
        else
        {
            if (lastWO1 != null)
            {
                Weapons[lastW1].SetActive(false);

                lastW1 = -1;
                lastWO1 = null;
            }

            if (Holder2.GetComponent<HolderScript>().children != null)
            {
                Weapons[Holder2.GetComponent<HolderScript>().weaponIndex].SetActive(true);
            }
        }

        if (isHolding2)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                GetSecondWeapon();
            }
        }
        else
        {
            if (lastWO2 != null)
            {
                Weapons[lastW2].SetActive(false);

                lastW2 = -1;
                lastWO2 = null;
            }
            if (Holder1.GetComponent<HolderScript>().children != null)
            {
                Weapons[Holder1.GetComponent<HolderScript>().weaponIndex].SetActive(true);
            }
        }
    }

    void GetFirstWeapon()
    {
        for (int i = 0; i < Weapons.Length; i++)
        {
            Weapons[i].SetActive(false);
        }

        Weapons[Holder1.GetComponent<HolderScript>().weaponIndex].SetActive(true);
    }

    void GetSecondWeapon()
    {
        for (int i = 0; i < Weapons.Length; i++)
        {
            Weapons[i].SetActive(false);
        }

        Weapons[Holder2.GetComponent<HolderScript>().weaponIndex].SetActive(true);
    }
}
