using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SButtonScript : MonoBehaviour
{
    public int price;

    [HideInInspector]public bool checkedBool;

    [HideInInspector]public Button thisButton;

    private ShopScript shopScript;

    public string functionName;

    public bool justOnce;

    [HideInInspector]public bool sold;

    private void Start()
    {
        thisButton = this.GetComponent<Button>();

        shopScript = GameObject.Find("Shop").GetComponent<ShopScript>();
    }

    private void Update()
    {
        if (!sold)
        {
            int moneyDiff = shopScript.Money - shopScript.cost;

            if (checkedBool)
            {
                GetComponent<Image>().color = Color.gray;
            }
            else
            {
                GetComponent<Image>().color = Color.green;
            }

            if (moneyDiff >= price)
            {
                thisButton.enabled = true;
            }
            else
            {
                if (!checkedBool)
                {
                    thisButton.enabled = false;
                    GetComponent<Image>().color = Color.red;
                }
            }
        }
        else
        {
            thisButton.enabled = false;

            this.GetComponentInChildren<Text>().text = "SOLD";
            GetComponent<Image>().color = Color.clear;
            this.GetComponentInChildren<Text>().color = Color.red;
        }
    }

    public void BoolFunction()
    {
        if (!checkedBool)
        {
            checkedBool = true;
            shopScript.cost += price;
        }
        else
        {
            checkedBool = false;
            shopScript.cost -= price;
        }
    }

    public void BuyFunction()
    {
        //Call the buying Function...

        if (checkedBool)
        {
            if (!justOnce)
            {
                shopScript.MainVoid(functionName);
            }
            else
            {
                shopScript.MainVoid(functionName);

                sold = true;
            }
        }
    }

}
