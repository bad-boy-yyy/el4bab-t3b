using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

public class HealthScript : MonoBehaviour
{

    public float startingHealth;
    public float healthSmoothTime;

    [HideInInspector]public float currentHealth;


    public float startingHunger;
    public float hungerSmoothness;
    [HideInInspector]public float currentHunger;

    [SerializeField]float hungerRate;

    public Image healthImage;
    public Image HungerImage;

    public bool IamHungry;

    private void Start()
    {
        currentHealth = startingHealth;
        currentHunger = startingHunger;

        InvokeRepeating("HungerDecrease", hungerRate, hungerRate);
    }

    private void Update()
    {
        //show the health on the health indecator..
        healthImage.fillAmount = Mathf.Lerp(healthImage.fillAmount, currentHealth / startingHealth,healthSmoothTime * Time.deltaTime);
        HungerImage.fillAmount = Mathf.Lerp(HungerImage.fillAmount, currentHunger / startingHunger, hungerSmoothness * Time.deltaTime);

        //testing the health system..
        if (Input.GetKeyDown(KeyCode.T))
        {
            CameraShaker.Instance.ShakeOnce(3f, 4, .1f, 1);
            currentHealth -= 10f;
            Debug.Log(currentHealth);
        }
    }

    void HungerDecrease()
    {
        if (currentHunger > 0)
        {
            currentHunger -= 0.1f;
        }
        else if (currentHunger <= 0)
        {
            currentHealth -= 0.1f;
        }
    }
}
