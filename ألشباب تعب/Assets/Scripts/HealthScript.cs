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

    [SerializeField] Animator TakeDamagePPVAnimator;

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

    public float startingArmor;
    public float armorSmoothness;

    [HideInInspector]public float currentArmor;

    public GameObject armorObj;
    public Image armorImage;
    private bool isAromr;


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
        if (isAromr) { armorImage.fillAmount = Mathf.Lerp(armorImage.fillAmount, currentArmor / startingArmor, armorSmoothness * Time.deltaTime); }

        if (currentArmor <= 0)
        {
            isAromr = false;
            armorObj.SetActive(false);
        }

        if (currentHunger > startingHunger / 4)
        {
            currentHealth = Mathf.Lerp(currentHealth, startingHealth, 0.01f * Time.deltaTime);
        }

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
        currentHunger -= 2f;
        yield return new WaitForSeconds(1.5f);
        isHungryDecreasing = false;
        
    }
    public void TakeDamage(float dmg)
    {
        TakeDamagePPVAnimator.CrossFade("TD_Start", 0.001f);
        if (isAromr)
        {
            CameraShaker.Instance.ShakeOnce(1f, 2, .1f, 1);
            currentArmor -= dmg;
        }
        else
        {
            CameraShaker.Instance.ShakeOnce(1f, 2, .1f, 1);
            currentHealth -= dmg;
        }
    }

    public void ActivateArmor()
    {
        isAromr = true;
        currentArmor = startingArmor;
        armorObj.SetActive(true);
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
