using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public GameObject weaponsPanel;
    public GameObject upgradesPanel;
    public GameObject charactersPanel;

    public Button weaponsButton;
    public Button upgradesButton;
    public Button charactersButton;

    private Color normalBColor;

    public Transform UPanel1;
    public Transform UPanel2;

    public Transform UPanel1Pos;
    public Transform UPanel2Pos;
    public Transform thirdPos;

    public float smoothness;

    bool canMove;
    bool next;
    bool back;

    public GameObject UNxtButton;
    public GameObject UBckButton;
    void Start()
    {
        normalBColor = upgradesButton.GetComponent<Image>().color;

        WeaponsButton();

        UPanel1Pos.position = UPanel1.transform.position;
        UPanel2Pos.position = UPanel2.transform.position; 
    }

    void LateUpdate()
    {
        if (canMove)
        {
            if (next)
            {
                UPanel1.transform.position = Vector2.Lerp(UPanel1.transform.position, thirdPos.position, Time.deltaTime * smoothness);
                UPanel2.transform.position = Vector2.Lerp(UPanel2.transform.position, UPanel1Pos.position, Time.deltaTime * smoothness);
            }
            else if (back)
            {
                UPanel1.transform.position = Vector2.Lerp(UPanel1.transform.position, UPanel1Pos.position, Time.deltaTime * smoothness);
                UPanel2.transform.position = Vector2.Lerp(UPanel2.transform.position, UPanel2Pos.position, Time.deltaTime * smoothness);
            }
        }
    }

    public void WeaponsButton()
    {
        weaponsButton.GetComponent<Image>().color = Color.cyan;
        upgradesButton.GetComponent<Image>().color = normalBColor;
        charactersButton.GetComponent<Image>().color = normalBColor;

        weaponsPanel.SetActive(true);
        upgradesPanel.SetActive(false);
        charactersPanel.SetActive(false);
    }

    public void UpgradesButton()
    {
        weaponsButton.GetComponent<Image>().color = normalBColor;
        upgradesButton.GetComponent<Image>().color = Color.cyan;
        charactersButton.GetComponent<Image>().color = normalBColor;

        weaponsPanel.SetActive(false);
        upgradesPanel.SetActive(true);
        charactersPanel.SetActive(false);
    }

    public void CharactersButton()
    {
        weaponsButton.GetComponent<Image>().color = normalBColor;
        upgradesButton.GetComponent<Image>().color = normalBColor;
        charactersButton.GetComponent<Image>().color = Color.cyan;

        weaponsPanel.SetActive(false);
        upgradesPanel.SetActive(false);
        charactersPanel.SetActive(true);
    }

    public void UNextButton()
    {
        UNxtButton.SetActive(false);
        UBckButton.SetActive(true);

        canMove = true;
        next = true;
        back = false;

        CancelInvoke("canMoveFalse");

        Invoke("canMoveFalse", 1);
    }

    public void UBackButton()
    {
        UBckButton.SetActive(false);
        UNxtButton.SetActive(true);

        canMove = true;
        next = false;
        back = true;

        CancelInvoke("canMoveFalse");
        Invoke("canMoveFalse", 1);
    }

    private void canMoveFalse()
    {
        canMove = false;
    }
}
