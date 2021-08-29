using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int survivalHours;
    private int survivalDays;
    public Text survivalTimeTxt;

    void Start()
    {
        InvokeRepeating("IncreaseTime", 15, 15);
    }

    void Update()
    {
        SurvivalTxtFunction();
    }

    void IncreaseTime()
    {
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
}
