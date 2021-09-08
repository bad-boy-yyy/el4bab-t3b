using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCrafting : MonoBehaviour
{
    private GameObject Player;
    private CraftingManager craftingManager;

    public float Health;
    public float ItemsNum;

    private Color normalColor;
    private Vector2 normalPos;
    private Vector2 wantedPos;

    public string name;

    void Start()
    {
        Player = GameObject.Find("Player");
        craftingManager = GameObject.Find("CraftingManager").GetComponent<CraftingManager>();

        normalColor = GetComponent<SpriteRenderer>().color;
        normalPos = (Vector2)transform.position;
    }

    void Update()
    {
        wantedPos = craftingManager.goPos;

        if (craftingManager.currentWeapon == null)
        {
            if (Vector2.Distance((Vector2)transform.position, (Vector2)Player.transform.position) <= 3.5f)
            {
                if (!craftingManager.isCrafting)
                {
                    craftingManager.CanCraft(gameObject);
                }
            }
            else if (Vector2.Distance((Vector2)transform.position, (Vector2)Player.transform.position) > 3.5f && Vector2.Distance((Vector2)transform.position, (Vector2)Player.transform.position) < 3.6)
            {
                craftingManager.DisableCrafting();
            }
        }
    }

    public void TakeDamage()
    {
        StartCoroutine(TakeDamageCoroutine());
    }

    private IEnumerator TakeDamageCoroutine()
    {
        float startingTime = Time.time;
        float duration = 0.2f;

        while (Time.time < startingTime + duration)
        {
            float t = (Time.time - startingTime) / duration;
            GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, Color.gray, t);
            transform.position = Vector3.Lerp(transform.position, wantedPos, t);
            yield return null;
        }
        GetComponent<SpriteRenderer>().color = Color.gray;

        if (Health > 1)
        {
            Health--;
        }
        else if (Health <= 1)
        {
            craftingManager.ItemDestroy();
        }

         startingTime = Time.time;
         duration = 0.1f;

        while (Time.time < startingTime + duration)
        {
            float t = (Time.time - startingTime) / duration;
            GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, normalColor, t);
            transform.position = Vector3.Lerp(transform.position, normalPos, t);
            yield return null;
        }

        GetComponent<SpriteRenderer>().color = normalColor;
        transform.position = normalPos;
    }
}
