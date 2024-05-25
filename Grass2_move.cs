using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass2_move : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime); 
    }
}
