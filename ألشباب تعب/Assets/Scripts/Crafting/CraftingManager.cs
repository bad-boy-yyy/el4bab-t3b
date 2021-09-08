using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public GameObject pressTxt;
    public GameObject moveAwayTxt;

    private bool canCraft;
    public bool isCrafting;

    private GameObject currentItem;

    public Transform player;
    public GameObject Axe;

    public GameObject currentWeapon;
    [HideInInspector]
    public Vector2 goPos;

    public GameObject WoodPrefab;
    public GameObject RockPrefab;
    public GameObject SteelPrefab;

    private void Update()
    {
        if (currentItem != null)
        {
            if (player.position.x < currentItem.transform.position.x)
            {
                Axe.transform.localScale = new Vector3(1, Axe.transform.localScale.y);
                goPos = new Vector2(currentItem.transform.position.x + 0.02f, currentItem.transform.position.y + -0.02f);
            }
            else if (player.position.x > currentItem.transform.position.x)
            {
                Axe.transform.localScale = new Vector3(-1, Axe.transform.localScale.y);
                goPos = new Vector2(currentItem.transform.position.x + -0.02f, currentItem.transform.position.y + -0.02f);
            }
        }


        if (canCraft)
        {
            pressTxt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                EnableCrafting();
            }
        }
        else
        {
            pressTxt.SetActive(false);
        }

        if (!canCraft && isCrafting)
        {
            moveAwayTxt.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                currentItem.GetComponent<ItemCrafting>().TakeDamage();
                Axe.GetComponent<Animator>().CrossFadeInFixedTime("AxeHitAnimation", 0.1f);
            }
        }
        else
        {
            moveAwayTxt.SetActive(false);
        }
    }

    public void CanCraft(GameObject item)
    {
        canCraft = true;
        currentItem = item;
    }

    public void EnableCrafting()
    {
        canCraft = false;
        isCrafting = true;

        if (currentWeapon != null) { currentWeapon.SetActive(false); }

        Axe.SetActive(true);
    }

    public void DisableCrafting()
    {
        canCraft = false;
        isCrafting = false;
        moveAwayTxt.SetActive(false);

        currentItem = null;

        if (currentWeapon != null) { currentWeapon.SetActive(true); }
        Axe.SetActive(false);
    }

    public void ItemDestroy()
    {
        Invoke(currentItem.GetComponent<ItemCrafting>().name, 0);
    }

    private void TreeDestroy()
    {
        for (int i = 0; i < currentItem.GetComponent<ItemCrafting>().ItemsNum; i++)
        {
            GameObject m = Instantiate(WoodPrefab, currentItem.transform.position, Quaternion.identity) as GameObject;
            m.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-0.3f, 0.3f), Random.Range(1, 2)) * 1000 * Time.deltaTime, ForceMode2D.Impulse);
        }

        Destroy(currentItem);
        DisableCrafting();
    }

    private void RockDestroy()
    {
        for (int i = 0; i < currentItem.GetComponent<ItemCrafting>().ItemsNum; i++)
        {
            GameObject m = Instantiate(RockPrefab, currentItem.transform.position, Quaternion.identity) as GameObject;
            m.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-0.3f, 0.3f), Random.Range(1, 2)) * 1000 * Time.deltaTime, ForceMode2D.Impulse);
        }

        Destroy(currentItem);
        DisableCrafting();
    }

    private void SteelDestroy()
    {
        for (int i = 0; i < currentItem.GetComponent<ItemCrafting>().ItemsNum; i++)
        {
            GameObject m = Instantiate(SteelPrefab, currentItem.transform.position, Quaternion.identity) as GameObject;
            m.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-0.3f, 0.3f), Random.Range(1, 2)) * 1000 * Time.deltaTime, ForceMode2D.Impulse);
        }

        Destroy(currentItem);
        DisableCrafting();
    }
}
