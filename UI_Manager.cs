using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;

public class UI_Manager : MonoBehaviour
{
    //버튼 관리----------------------------------------------------------------------------------------

    public static string Player = "Player1"; //현재 선택중인 Player.

    //Player 선택 버튼
    public void Player1_Button()
    {
        Player = "Player1";
    }

    public void Player2_Button()
    {
        Player = "Player2";
    }

    public void Player3_Button()
    {
        Player = "Player3";
    }

    //Play 버튼
    public void Player_Run_Button()
    {
        if(stage == "stage1")
        {
            SceneManager.LoadScene("Stage1");
        }

        if(stage == "stage2")
        {
            SceneManager.LoadScene("Stage2");
        }

        if(stage == "stage3")
        {
            SceneManager.LoadScene("Stage3");
        }
    }

    public GameObject HpShopUI;

    //Hp Shop 버튼
    public void HpShopButton()
    {
        HpShopUI.SetActive(true);
    }

    public void HpShopCloseButton()
    {
        HpShopUI.SetActive(false);
    }

    //Exit 버튼
    public void ExitButton()
    {
        Application.Quit();
    }

    //해상도 관리------------------------------------------------------------------------------------

    public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenBtn;

    List<Resolution> resolutions = new List<Resolution>();
    FullScreenMode screenMode;

    int resolutionNum;
    int optionNum = 0;

    void InitUI()
    {
        var sortedResolutions = Screen.resolutions.Where(res => res.refreshRate == Screen.currentResolution.refreshRate).OrderByDescending(res => res.width * res.height).ToList();
        resolutions = sortedResolutions;
        resolutionDropdown.options.Clear();
        optionNum = 0;

        foreach(Resolution item in resolutions)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();
            option.text = item.width + "x" + item.height + " " + item.refreshRate + "Hz";
            resolutionDropdown.options.Add(option);

            if(item.width == Screen.width && item.height == Screen.height)
            {
                resolutionDropdown.value = optionNum;
            }

            optionNum++;
        }

        resolutionDropdown.RefreshShownValue();
        fullscreenBtn.isOn = Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow) ? true : false;
    }

    public void DropdownOptionChange(int x)
    {
        resolutionNum = x;
        OkBtnClick();
    }

    public void FullScreenBtn(bool isFull)
    {
        screenMode = isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
        OkBtnClick();
    }

    public void OkBtnClick()
    {
        Screen.SetResolution(resolutions[resolutionNum].width, resolutions[resolutionNum].height, screenMode);
    }

    //스테이지 선택 버튼, UI관리-------------------------------------------------------------------------------------------

    public GameObject B1;
    public GameObject B2;
    public GameObject B3;

    public static string stage = "stage1"; //현재 선택중인 stage.

    public void B1_Button()
    {
        stage = "stage1";
    }

    public void B2_Button()
    {
        B1.SetActive(false);
        B2.SetActive(true);
        B3.SetActive(false);

        stage = "stage2";
    }

    public void B3_Button()
    {
        B1.SetActive(false);
        B2.SetActive(false);
        B3.SetActive(true);

        stage = "stage3";
    }

    //스테이지 선택 되었을때 실행.
    void StageChoice()
    {
        if(stage == "stage1")
        {
            B1.SetActive(true);
            B2.SetActive(false);
            B3.SetActive(false);
        }

        if(stage == "stage2")
        {
            B1.SetActive(false);
            B2.SetActive(true);
            B3.SetActive(false);
        }

        if(stage == "stage3")
        {
            B1.SetActive(false);
            B2.SetActive(false);
            B3.SetActive(true);
        }
    }
    
    //Money UI관리----------------------------------------------------------------------------------------------------

    public TMP_Text money_text;
    public static int money;

    void Money_UI()
    {
        money_text.text = ""+money; //Money Text UI에 int형 money변수값을 출력.
    }

    //-----------------------------------------------------------------------------------------------------------------

    public GameObject Stage1_Background;
    public GameObject Stage3_Background;

    public GameObject[] star = new GameObject[3];

    void StarManager() //별UI 관리.
    {
        if(stage == "stage2")
        {
            star[0].SetActive(true);
            star[1].SetActive(false);
            star[2].SetActive(false);
        }

        if(stage == "stage3")
        {
            star[0].SetActive(true);
            star[1].SetActive(true);
            star[2].SetActive(false);
        }

        if(stage == "stage3_clear" || Stage3_Clear.stage_all_clear)
        {
            star[0].SetActive(true);
            star[1].SetActive(true);
            star[2].SetActive(true);

            Stage1_Background.SetActive(true);
            Stage3_Background.SetActive(false);
        }
    }

    //Player 선택 관리.------------------------------------------------------------------------------------------------------

    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;

    public GameObject P1_Choice;
    public GameObject P2_Choice;
    public GameObject P3_Choice;

    void PlayerChoice()
    {
        if(Player == "Player1")
        {
            Player1.SetActive(true);
            Player2.SetActive(false);
            Player3.SetActive(false);

            P1_Choice.SetActive(true);
            P2_Choice.SetActive(false);
            P3_Choice.SetActive(false);
        }

        if(Player == "Player2")
        {
            Player1.SetActive(false);
            Player2.SetActive(true);
            Player3.SetActive(false);

            P1_Choice.SetActive(false);
            P2_Choice.SetActive(true);
            P3_Choice.SetActive(false);
        }

        if(Player == "Player3")
        {
            Player1.SetActive(false);
            Player2.SetActive(false);
            Player3.SetActive(true);

            P1_Choice.SetActive(false);
            P2_Choice.SetActive(false);
            P3_Choice.SetActive(true);
        }
    }

    //-------------------------------------------------------------------------------------------------------------------

    //Hp상점
    public static int Hp_recovery_item = 5; //Hp회복 아이템
    public TMP_Text Hp_item_text;

    public GameObject buy_failure_UI;

    public void buybutton() //Hp구입 버튼
    {
        if(money >= 10)
        {
            Hp_recovery_item++;
            money -= 10;
        }

        else
        {
            buy_failure();
        }
    }

    void Hp_item_text_update()
    {
        Hp_item_text.text = ""+Hp_recovery_item;
    }

    //버튼
    public void buy_failure()
    {
        buy_failure_UI.SetActive(true);
    }

    public void buy_failure_UI_close()
    {
        buy_failure_UI.SetActive(false);
    }


    //-------------------------------------------------------------------------------------------------------------------

    public AudioSource MainBGM;
    public Slider SoundBar;

    public static float Audio_value;

    void Awake()
    {
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
    }

    void Start()
    { 
        InitUI();
    }

    void Update()
    {
        StarManager(); //스테이지 클리어 시 UI에 추가되는 별 UI.
        PlayerChoice(); //플레이어 선택.
        StageChoice(); //스테이지 선택.
        Money_UI(); //Money UI 관리.
        Hp_item_text_update(); //Hp item text update

        Audio_value = SoundBar.value;
        MainBGM.volume = Audio_value;
    }
}
