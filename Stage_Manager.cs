using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage_Manager : MonoBehaviour
{
    public static string stage = "Stage1";

    public GameObject Look1;
    public GameObject Look2;

    void Update()
    {
        if(stage == "Stage1_Clear")
        {
            Look1.SetActive(false);
            Look2.SetActive(true);
        }

        if(stage == "Stage2_Clear")
        {
            Look1.SetActive(false);
            Look2.SetActive(false);
        }

        if(stage == "Stage3_Clear")
        {
            Look1.SetActive(false);
            Look2.SetActive(false);
        }
    }
}
