using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon1_move : MonoBehaviour
{
    public float speed = 20f;

    void Start()
    {
        Invoke("Destroy_weapon", 10f);
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void Destroy_weapon()
    {
        Destroy(gameObject);
    }
}
