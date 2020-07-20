using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigResolution : MonoBehaviour
{
   
    void Start()
    {

        Screen.SetResolution(2500, 350, true);

        QualitySettings.SetQualityLevel(5, true);
        
    }

  
}
