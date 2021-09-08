using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesScript : MonoBehaviour
{

    [HideInInspector]
    public int Wood, Steel, Rock, Money;

    public Text woodTxt, steelTxt, rockTxt, moneyTxt;

    private ShopScript shopScript;

    void Start()
    {
        shopScript = GameObject.Find("Shop").GetComponent<ShopScript>();
        Money = (int)shopScript.Money;
    }

    void Update()
    {
        woodTxt.text = Wood.ToString();
        steelTxt.text = Steel.ToString();
        rockTxt.text = Rock.ToString();
        moneyTxt.text = Money.ToString();
    }

}
