using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    private GameObject player;

    public GameObject pressText;

    private bool canOpen;
    [HideInInspector]public bool isShopOpened;
    

    public GameObject shopPanel;

    public float shopDistance;

    public float Money;
    public float cost;
    private float remaining;

    public Text moneyTxt;
    public Text costTxt;
    public Text remainingTxt;

    public GameObject[] UpgradeButtons;

    public GameObject[] IWeapons;
    public GameObject[] IHolders;

    public int holderIndex = -1;
    public int weaponIndex = 0;

    public GameObject[] Weapons;

    public static ShopScript Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        remaining = Money - cost;

        moneyTxt.text = "<color=white>" + Money.ToString("N0") + "</color> $";
        costTxt.text = "Total : <color=white>" + cost.ToString("N0") + "</color> $";
        remainingTxt.text = "Remaining : <color=white>" + remaining.ToString("N0") + "</color> $";

        CanOpenFunction();
    }

    private void CanOpenFunction()
    {
        isShopOpened = shopPanel.activeInHierarchy;


        //Checking if the player is near to the shop or not..

        if (Vector2.Distance(transform.position, player.transform.position) <= shopDistance)
        {
            pressText.SetActive(true);
            canOpen = true;
        }
        else
        {
            pressText.SetActive(false);
            canOpen = false;
            if (shopPanel.activeSelf)
            {
                shopPanel.SetActive(false);
            }
        }

        if (canOpen)
        {
            //If key "F" is pressed open the shop..
            if (Input.GetKeyDown(KeyCode.E))
            {
                //pressText.SetActive(false);

                shopPanel.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackButton();
        }
    }

    public void BuyButton()
    {
        //decrease the money by....
        Money -= cost;

        //reset the cost...
        cost = 0;

        for (int i = 0; i < UpgradeButtons.Length; i++)
        {
            if(!UpgradeButtons[i].GetComponent<SButtonScript>().sold)
            UpgradeButtons[i].GetComponent<SButtonScript>().BuyFunction();

            if (!UpgradeButtons[i].GetComponent<SButtonScript>().justOnce)
            UpgradeButtons[i].GetComponent<SButtonScript>().checkedBool = false;
        }
    }

    public void ResetButton()
    {
        //reset the upgrades that i have chosen...

        cost = 0;

        for (int i = 0; i < UpgradeButtons.Length; i++)
        {
            if (!UpgradeButtons[i].GetComponent<SButtonScript>().sold)
            UpgradeButtons[i].GetComponent<SButtonScript>().checkedBool = false;
        }
    }

    public void BackButton()
    {
        shopPanel.SetActive(false);

        ResetButton();
    }

    #region UpgradesFunctions

    public void MainVoid(string name)
    {

        //apply the function that we have chosen by the button index...

        #region Nothing
        /*
        int rand = index;

        switch (index)
        {
            case 0:
                Drink();
                break;

            case 1:
                Eat();
                break;

            case 2:
                IncreaseSpeed();
                break;

            case 3:
                IncreaseHealth();
                break;

            case 4:
                DamageIncrease();
                break;

            case 5:
                Bullet10();
                break;

            case 6:
                Bullet20();
                break;

            case 7:
                Bullet50();
                break;
         */
        #endregion

        Invoke(name, 0);
    }

    //we will put the commands in the below functions..

    #region Weapons
    private void AK()
    {
        
        WeaponBuyFunction(0);
    }

    private void DEAGLE()
    {
      


        WeaponBuyFunction(1);
    }

    private void M1911()
    {
       

        WeaponBuyFunction(2);
    }

    private void Thombson()
    {
       

        WeaponBuyFunction(3);
    }

    private void MP40()
    {
       
        WeaponBuyFunction(4);
    }

    private void UZI()
    {
       

        WeaponBuyFunction(5);
    }

    private void HUNTINGRIFLE()
    {
       

        WeaponBuyFunction(6);
    }


    private void REVOLVER()
    {
     
        WeaponBuyFunction(7);
    }

    private void SCAR()
    {
      
        WeaponBuyFunction(8);
    }

    private void WeaponBuyFunction(int WIndex)
    {
        for (int i = 0; i < IHolders.Length; i++)
        {
            if (!IHolders[holderIndex].GetComponent<HolderScript>().holding)
            {
                IWeapons[WIndex].SetActive(true);

                IWeapons[WIndex].GetComponent<RectTransform>().position = IHolders[holderIndex].GetComponent<RectTransform>().position;

                IWeapons[WIndex].transform.SetParent(IHolders[holderIndex].transform);

                IHolders[holderIndex].GetComponent<HolderScript>().holding = true;

                IWeapons[WIndex].GetComponent<IButtonScript>().lastHolder = IHolders[holderIndex];

                holderIndex++;

                break;
            }
            if (IHolders[holderIndex].GetComponent<HolderScript>().holding)
            {
                if (holderIndex <= 6)
                {
                    holderIndex++;
                }
                else if (holderIndex >= 7)
                {
                    holderIndex = 0;

                    WeaponBuyFunction(WIndex);

                    break;
                }
            }
        }
    }

    #endregion

    #region Upgrades
    private void Drink()
    {
        Debug.Log("Drink");

        GameObject.Find("Player").GetComponent<HealthScript>().currentHunger +=
        (GameObject.Find("Player").GetComponent<HealthScript>().startingHunger
        - GameObject.Find("Player").GetComponent<HealthScript>().currentHunger) / 2;
    }

    private void Eat()
    {
        Debug.Log("Eat");

        GameObject.Find("Player").GetComponent<HealthScript>().currentHunger = 100f;
    }

    private void IncreaseSpeed()
    {
        GameObject.Find("Player").GetComponent<PlayerPlatformerMovement>().runSpeed *= 1.2f;
    }

    private void IncreaseHealth()
    {
        Debug.Log("IncreaseHealth");

        GameObject.Find("Player").GetComponent<HealthScript>().currentHealth = 100f;
    }

    private void Armor()
    {
        Debug.Log("Armor");
        GameObject.Find("Player").GetComponent<HealthScript>().ActivateArmor();
    }

    private void Flying()
    {
        Debug.Log("Flying");
    }

    private void DamageIncrease()
    {
        Debug.Log("DamageIncrease");

        for (int i = 0; i < Weapons.Length; i++)
        {
            Weapons[i].GetComponent<GunSystem>().damage *= 1.2f;
        }
    }

    private void FireRate()
    {
        Debug.Log("FireRate");

        for (int i = 0; i < Weapons.Length; i++)
        {
            Weapons[i].GetComponent<GunSystem>().firerate *= 0.75f;
        }
    }

    private void Bullet50()
    {
        
    }

    private void Bullet20()
    {
        
    }

    private void Bullet10()
    {
        
    }

    private void ReloadTime()
    {
        for (int i = 0; i < Weapons.Length; i++)
        {
            Weapons[i].GetComponent<GunSystem>().reloadTime *= 0.8f;
        }
    }
    #endregion

    #region Characters
    private void Character1()
    {
        Debug.Log("Character1");
    }
    private void Character2()
    {
        Debug.Log("Character2");
    }
    private void Character3()
    {
        Debug.Log("Character3");
    }
    private void Character4()
    {
        Debug.Log("Character4");
    }
    #endregion
    #endregion
}