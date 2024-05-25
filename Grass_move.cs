using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass_move : MonoBehaviour
{
    public float speed = 8f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
