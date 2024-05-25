using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass3_move : MonoBehaviour
{
    public float speed = 15f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime); 
    }
}
