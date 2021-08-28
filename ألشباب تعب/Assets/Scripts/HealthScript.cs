using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{

    public float startingHealth;

    [HideInInspector]public float currentHealth;

    public Image healthImage;
    public Image JuiceImage;

    private void Start()
    {
        currentHealth = startingHealth;
    }

    private void Update()
    {
        //show the health on the health indecator..
        healthImage.fillAmount = currentHealth / startingHealth;

        //testing the health system..
        if (Input.GetKeyDown(KeyCode.F))
        {
            currentHealth -= 10f;
            Debug.Log(currentHealth);
        }

    }
}
