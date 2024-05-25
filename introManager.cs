using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introManager : MonoBehaviour
{
    void Awake()
    {
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
    }

    void Start()
    {
        Invoke("MainSceneGo", 20.5f);
    }

    void MainSceneGo()
    {
        SceneManager.LoadScene("MainScene");
    }
}
