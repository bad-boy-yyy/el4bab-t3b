using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    private GameObject player;

    public GameObject pressText;

    private bool canOpen;

    public GameObject shopPanel;

    public float shopDistance;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
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

                shopPanel.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            shopPanel.SetActive(false);
        }
    }
}
