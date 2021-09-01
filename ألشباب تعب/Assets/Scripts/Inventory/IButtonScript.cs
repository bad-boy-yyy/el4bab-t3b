using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IButtonScript : MonoBehaviour
{
    private Vector2 wantedPos;
    private Vector2 mousePos;

    private Camera cam;

    public bool isHolding = false;

    private Transform myTr;

    public GameObject[] Holders;

    public int index;

    private Vector2 lastPos;

    public GameObject lastHolder;

    private bool lastH;

    void Start()
    {
        myTr = GetComponent<Transform>();
        cam = Camera.main;

        wantedPos = myTr.localPosition;
    }

    void Update()
    {
        mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        if (isHolding)
        {
            myTr.position = (Vector2)cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        }
    }

    public void ChangeBool(bool mybool)
    {
        isHolding = mybool;

        if (Input.GetMouseButtonDown(0))
        {
            lastPos = GetComponent<RectTransform>().localPosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (lastHolder != null)
            {
                lastHolder.GetComponent<HolderScript>().holding = false;
            }

            GetToHold();

            if (GetComponent<RectTransform>().localPosition.x != 0)
            {
                GetComponent<RectTransform>().localPosition = Vector2.zero;

                if (lastHolder != null)
                {
                    lastHolder.GetComponent<HolderScript>().holding = true;
                }
            }
        }
    }

    private void GetToHold()
    {
        for (int i = 0; i < Holders.Length; i++)
        {
            if (Vector2.Distance(transform.position, Holders[i].transform.position) <= 1.5f)
            {
                if (!Holders[i].GetComponent<HolderScript>().holding)
                {
                    transform.SetParent(Holders[i].transform);

                    GetComponent<RectTransform>().localPosition = Vector2.zero;

                    Holders[i].GetComponent<HolderScript>().holding = true;

                    lastHolder = Holders[i].gameObject;
                }
                else if (Holders[i].GetComponent<HolderScript>().holding && Holders[i].GetComponent<HolderScript>().isMain)
                {
                    //Holders[i].GetComponent<HolderScript>().children.SetParent(lastHolder.transform);

                    Holders[i].GetComponentInChildren<RectTransform>().localPosition = Vector2.zero;

                    Holders[i].GetComponentInChildren<IButtonScript>().lastHolder = lastHolder;

                    GetComponentInParent<HolderScript>().holding = true;

                    transform.SetParent(Holders[i].transform);

                    GetComponent<RectTransform>().localPosition = Vector2.zero;

                    Holders[i].GetComponent<HolderScript>().holding = true;

                    lastHolder = Holders[i].gameObject;

                }
            }
        }
    }
}
