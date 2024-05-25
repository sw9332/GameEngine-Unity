using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Stage1_UI_Manager : MonoBehaviour
{
    public AudioSource BGM;

    public void RePlay()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void Main()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Stage1_Clear_Main_Button()
    {
        SceneManager.LoadScene("MainScene");
        Stage_Manager.stage = "Stage1_Clear";
    }

    public TMP_Text Stage1_Hp_item;

    void Start()
    {
        BGM.volume = UI_Manager.Audio_value;
    }

    void Update()
    {
        Stage1_Hp_item.text = ""+UI_Manager.Hp_recovery_item;
    }
}
