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

    public Image healthImage;
    public Image JuiceImage;

    private void Start()
    {
        currentHealth = startingHealth;
    }

    private void Update()
    {
        //show the health on the health indecator..
        healthImage.fillAmount = Mathf.Lerp(healthImage.fillAmount, currentHealth / startingHealth,healthSmoothTime * Time.deltaTime);

        //testing the health system..
        if (Input.GetKeyDown(KeyCode.T))
        {
            CameraShaker.Instance.ShakeOnce(3f, 4, .1f, 1);
            currentHealth -= 10f;
            Debug.Log(currentHealth);
        }

    }
}
