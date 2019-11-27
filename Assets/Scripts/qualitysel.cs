using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class qualitysel : MonoBehaviour
{
    public Button[] butoane;

    // Start is called before the first frame update
    void Start()
    {
        int qualityLevel = QualitySettings.GetQualityLevel();
        for (int i = 0; i<butoane.Length;i++)
        {
            if(i == qualityLevel-1)
            {
                butoane[i].enabled = false;
                break;
            }
        }

    }

    void enableall()
    {
        int qualityLevel = QualitySettings.GetQualityLevel();
        for (int i = 0; i < butoane.Length; i++)
        {
            butoane[i].enabled = true;
        }
    }
    
    public void low()
    {
        enableall();
        QualitySettings.SetQualityLevel(1, true);
        Start();
       // butoane[0].enabled = false;
    }
    public void medium()
    {
        enableall();
        QualitySettings.SetQualityLevel(2, true);
        Start();
        // butoane[1].enabled = false;
    }
    public void hard()
    {
        enableall();
        QualitySettings.SetQualityLevel(3, true);
        Start();
        //butoane[2].enabled = false;
    }
}
