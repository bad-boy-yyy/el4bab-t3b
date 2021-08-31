using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    public Button weaponsButton;
    public Button charactersButton;

    public GameObject weaponsPanel;
    public GameObject charcatersPanel;

    private Color normalColor;

    void Start()
    {
        normalColor = charactersButton.GetComponent<Image>().color;

        WeaponsButton();
    }

    public void WeaponsButton()
    {
        weaponsButton.GetComponent<Image>().color = Color.cyan;
        charactersButton.GetComponent<Image>().color = normalColor;

        weaponsPanel.SetActive(true);
        charcatersPanel.SetActive(false);
    }

    public void CharactersButton()
    {
        weaponsButton.GetComponent<Image>().color = normalColor;
        charactersButton.GetComponent<Image>().color = Color.cyan;

        weaponsPanel.SetActive(false);
        charcatersPanel.SetActive(true);
    }
}
