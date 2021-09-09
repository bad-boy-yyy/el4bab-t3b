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
    private float lightRot;
        float newRot;

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
        newRot = -323.211f;

        currentTime = 6;
        survivalHours = 1;

        currentSky = SkySprites[currentSkyIndex];
        wantedSky = SkySprites[currentSkyIndex + 1];
        SkyFunction();

        //InvokeRepeating("IncreaseRotationOfSun", 0.5f, 0.5f);
        InvokeRepeating("IncreaseTime", hourRate, hourRate);
    }

    void Update()
    {
        Debug.Log(newRot);
        newRot = Mathf.LerpAngle(newRot, lightRot, 1 * Time.deltaTime);
       // sun.transform.rotation = Vector3.(newRot, 0, 0,1);
        Debug.Log(Time.timeScale + " Time");
        if(Input.GetKeyDown(KeyCode.I))
        {
            Time.timeScale += 0.5f;
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            Time.timeScale -= 0.5f;
        }

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
    protected void IncreaseRotationOfSun()
    {
        sun.transform.Rotate(new Vector3(1, 0, 0),0.1875f);
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
       // sun.transform.Rotate(new Vector2(1 , 0), 0.19f);
        
    }

    IEnumerator SunCoroutine()
    {
        float startTime = Time.time;
        float duration = hourRate;

        while (Time.time < startTime + duration)
        {
            float r = sun.transform.rotation.x;
            float t = (Time.time - startTime) / duration;
            
                //Mathf.Lerp(sun.transform.rotation.x, sun.transform.rotation.x + 15, t), sun.transform.rotation.y, 0);
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
        StartCoroutine(SunCoroutine());
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
    void ChangeTime()
    {
        if(currentTime == 1)
        {
            lightRot = -270f;

        }
        if(currentTime == 2)
        {
            lightRot = -270f;

        }
        if(currentTime == 3)

        {
            lightRot = -273.119f;
        }
        if(currentTime == 4)
        {
            lightRot = -278.354f;
        }
        if(currentTime == 5)
        {
            lightRot = -299.955f;
        }
        if(currentTime == 6)
        {
            lightRot = -323.211f;
        }
        if(currentTime == 7)
        {
            lightRot = -325.166f;
        }
        if(currentTime == 8)
        {
            lightRot = -325.166f;
        }
        if(currentTime == 9)
        {
            lightRot = -325.166f;
        }
        if(currentTime == 10)
        {
            lightRot = -354.697f;
        }
        if(currentTime == 11)
        {
            lightRot = -357.195f;
        }
        if(currentTime == 12)
        {
            lightRot = -359.95f;
        }
                }
}
