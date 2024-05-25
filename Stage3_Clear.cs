using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage3_Clear : MonoBehaviour
{
    public static bool stage_all_clear = false;

    void Start()
    {
        UI_Manager.stage = "stage3_clear";
        stage_all_clear = true;
    }

    public void MainSceneButton()
    {
        SceneManager.LoadScene("MainScene");
    }
}
