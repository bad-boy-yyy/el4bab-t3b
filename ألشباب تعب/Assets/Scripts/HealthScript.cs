using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;
using UnityEngine.SceneManagement;

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

    bool isHungryDecreasing;
    bool isHungryTakeDamage;

    public static HealthScript Instance;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        currentHealth = startingHealth;
        currentHunger = startingHunger;

        InvokeRepeating("HungerDecrease", hungerRate, hungerRate);
    }

    private void Update()
    {
        //show the health on the health indecator..
        healthImage.fillAmount = Mathf.Lerp(healthImage.fillAmount, currentHealth / startingHealth, healthSmoothTime * Time.deltaTime);
        HungerImage.fillAmount = Mathf.Lerp(HungerImage.fillAmount, currentHunger / startingHunger, hungerSmoothness * Time.deltaTime);

        if(currentHealth < 1)
        {
            //Die
            Die();
        }

        //testing the health system..
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            currentHunger += 10f;
        }
        
        if (currentHunger > 0)
        {
            
           if(!isHungryDecreasing)
            {
                StartCoroutine(nameof(HungerDecrease));
            } 
        }
        else if (currentHunger <= 0)
        {
                if(!isHungryTakeDamage)
            {
                StartCoroutine(nameof(HungerTakeDamage));
            }
        }
    }

    IEnumerator HungerDecrease()
    {
        isHungryDecreasing = true;
        currentHunger -= 1f;
        yield return new WaitForSeconds(1.5f);
        isHungryDecreasing = false;
        
    }
    public void TakeDamage(float dmg)
    {
         CameraShaker.Instance.ShakeOnce(1f, 2, .1f, 1);
        currentHealth -= dmg;
    }
    IEnumerator HungerTakeDamage()
    {
        isHungryTakeDamage = true;
        TakeDamage(1f);
        yield return new WaitForSeconds(1);
        isHungryTakeDamage = false;
    }
    void Die()
    {
        int currentScene = SceneManager.sceneCount;
        SceneManager.LoadScene(0);
    }
}
