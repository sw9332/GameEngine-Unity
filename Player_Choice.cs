using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Choice : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;

    void Start()
    {
        if(UI_Manager.Player == "Player1")
        {
            Player1.SetActive(true);
            Player2.SetActive(false);
            Player3.SetActive(false);

            Destroy(Player2);
            Destroy(Player3);
        }

        if(UI_Manager.Player == "Player2")
        {
            Player1.SetActive(false);
            Player2.SetActive(true);
            Player3.SetActive(false);

            Destroy(Player1);
            Destroy(Player3);
        }

        if(UI_Manager.Player == "Player3")
        {
            Player1.SetActive(false);
            Player2.SetActive(false);
            Player3.SetActive(true);

            Destroy(Player1);
            Destroy(Player2);
        }
    }
}
