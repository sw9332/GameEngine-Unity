using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Stage2_UI_Manager : MonoBehaviour
{
    public AudioSource BGM;

    public void RePlay()
    {
        SceneManager.LoadScene("Stage2");
    }

    public void Main()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Stage2_Clear_Main_Button()
    {
        SceneManager.LoadScene("MainScene");
        Stage_Manager.stage = "Stage2_Clear";
    }

    public TMP_Text Stage2_Hp_item;

    void Start()
    {
        BGM.volume = UI_Manager.Audio_value;
    }

    void Update()
    {
        Stage2_Hp_item.text = ""+UI_Manager.Hp_recovery_item;
    }
}
