using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump : MonoBehaviour
{
    public Animator Jump;

    void Update()
    {
        Jump.Play("Player_Jump");
    }
}
