using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    private GameObject player;

    public GameObject pressText;

    private bool canOpen;

    public GameObject shopPanel;

    public float shopDistance;

    public int Money;
    public int cost;
    private int remaining;

    public Text moneyTxt;
    public Text costTxt;
    public Text remainingTxt;

    public GameObject[] UpgradeButtons;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        remaining = Money - cost;

        moneyTxt.text = "Money : " + Money.ToString();
        costTxt.text = "Cost : " + cost.ToString();
        remainingTxt.text = "Remaining : " + remaining.ToString();

        CanOpenFunction();
    }

    private void CanOpenFunction()
    {
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
        }


        if (canOpen)
        {
            //If key "E" is pressed open the shop..
            if (Input.GetKeyDown(KeyCode.E))
            {
                //pressText.SetActive(false);

                BackButton();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            shopPanel.SetActive(false);
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
            UpgradeButtons[i].GetComponent<SButtonScript>().BuyFunction();

            UpgradeButtons[i].GetComponent<SButtonScript>().checkedBool = false;
        }
    }

    public void ResetButton()
    {
        //reset the upgrades that i have chosen...

        cost = 0;

        for (int i = 0; i < UpgradeButtons.Length; i++)
        {
            UpgradeButtons[i].GetComponent<SButtonScript>().checkedBool = false;
        }
    }

    public void BackButton()
    {
        shopPanel.SetActive(false);

        ResetButton();
    }

    #region UpgradesFunctions

    public void MainVoid(int index)
    {
        //apply the function that we have chosen by the button index...

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
        }
    }

    //we will put the commands in the below functions..

    private void Drink()
    {
        Debug.Log("Drink");
    }

    private void Eat()
    {
        Debug.Log("Eat");
    }

    private void IncreaseSpeed()
    {
        Debug.Log("IncreaseSpeed");
    }

    private void IncreaseHealth()
    {
        Debug.Log("IncreaseHealth");
    }

    private void DamageIncrease()
    {
        Debug.Log("DamageIncrease");
    }

    private void Bullet10()
    {
        Debug.Log("Bullet10");
    }

    private void Bullet20()
    {
        Debug.Log("Bullet20");
    }

    private void Bullet50()
    {
        Debug.Log("Bullet50");
    }
    #endregion
}
