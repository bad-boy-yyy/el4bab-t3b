using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    int currentTime; 
    private int survivalHours;
    private int survivalDays;
    public Text survivalTimeTxt;
    public Text currentTimeTxt;
    public SpriteRenderer Sky;
    public Color m_SkyColor;
   

    void Start()
    {
        currentTime = 1;
        survivalHours = 1;
        InvokeRepeating("IncreaseTime", 10, 10);
        
    }

    void Update()
    {
        

       
        SurvivalTxtFunction();
        CurrentTimeTxtFunction();
    }
        
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
    

   

}
