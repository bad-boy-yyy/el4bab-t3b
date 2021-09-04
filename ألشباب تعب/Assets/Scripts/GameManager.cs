using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    private int currentTime; 
    private int survivalHours;
    private int survivalDays;
    public Text survivalTimeTxt;
    public Text currentTimeTxt;
    public Color m_SkyColor;

    public float hourRate;

    public GameObject[] Zombies;
    public Transform[] SpawnPoints;
    private float zombiesRate;

    public GameObject sun;
    public GameObject moon;

    #region skyVariables
    public SpriteRenderer firstSky;
    public SpriteRenderer secondSky;

    public Sprite[] SkySprites;
    private Sprite currentSky;

    private Sprite wantedSky;
    public Sprite opacity;
    public int currentSkyIndex;
    #endregion

    void Start()
    {
        currentTime = 6;
        survivalHours = 1;

        currentSky = SkySprites[currentSkyIndex];
        wantedSky = SkySprites[currentSkyIndex + 1];
        SkyFunction();

        InvokeRepeating("IncreaseTime", hourRate, hourRate);
    }

    void Update()
    {
        if (currentSkyIndex > 23)
        {
            currentSkyIndex = 0;
        }

        currentSky = SkySprites[currentSkyIndex];
        wantedSky = SkySprites[currentSkyIndex + 1];

        SurvivalTxtFunction();
        CurrentTimeTxtFunction();
        
        DayNight();
    }

    #region TimeFunctions
    void IncreaseTime()
    {
        if (currentTime < 24)
        {
            currentTime++;
        } else
        {
            currentTime = 1;
        }

        if (survivalHours < 24)
        {
            survivalHours++;
        }
        else if (survivalHours == 24)
        {
            survivalDays++;
            survivalHours = 1;
        }

        //StartCoroutine(SunCoroutine());
        SkyFunction();
    }

    void SurvivalTxtFunction()
    {
        if (survivalDays < 1)
        {
            survivalTimeTxt.text = survivalHours.ToString() + " hours";
        }
        else if (survivalDays >= 1 && survivalDays < 2)
        {
            survivalTimeTxt.text = survivalDays.ToString() + " Day, " + survivalHours.ToString() + " hours";
        }
        else if (survivalDays >= 2)
        {
            survivalTimeTxt.text = survivalDays.ToString() + " Days, " + survivalHours.ToString() + " hours";
        }
    }
    void CurrentTimeTxtFunction()
    {
        if (currentTime <= 12)
        {
            currentTimeTxt.text = currentTime.ToString() + " AM";
        }
        else if (currentTime > 12)
        {
            currentTimeTxt.text = ((currentTime - 12).ToString()) + " PM";
        }

    }
    #endregion

    void ZombiesManager()
    {
        int rand = Random.Range(0, Zombies.Length);
        int sRand = Random.Range(0, SpawnPoints.Length);
        Instantiate(Zombies[rand], SpawnPoints[sRand].position, Quaternion.identity);
    }

    void DayNight()
    {
        sun.transform.Rotate(new Vector2(1, 0), 0.19f);
    }

    IEnumerator SunCoroutine()
    {
        float startTime = Time.time;
        float duration = hourRate;

        while (Time.time < startTime + duration)
        {
            float t = (Time.time - startTime) / duration;
            transform.rotation = Quaternion.Euler(Mathf.Lerp(transform.rotation.x, transform.rotation.x + 15, t), transform.rotation.y, 0);
            yield return null;
        }
    }

    private void SkyFunction()
    {
        currentSkyIndex++;

        firstSky.sprite = currentSky;
        firstSky.color = new Color(firstSky.color.r, firstSky.color.g, firstSky.color.b, 255);

        secondSky.sprite = wantedSky;

        StartCoroutine(SkyCoroutine());
    }

    IEnumerator SkyCoroutine()
    {
        float startTime = Time.time;
        float duration = hourRate;

        while (Time.time < startTime + duration)
        {
            float t = (Time.time - startTime) / duration;
            firstSky.color = new Color(firstSky.color.r, firstSky.color.g, firstSky.color.b, Mathf.Lerp(1, 0, t));
            yield return null;
        }

        
    }
}
