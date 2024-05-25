using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        Invoke("Destroy_Bullet", 5f);
    }

    void Update()
    {
        transform.Translate(new Vector3(13.5f,0,0) * Time.deltaTime);  
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Boss")
        {
            Destroy(gameObject);
        }
    }

    void Destroy_Bullet()
    {
        Destroy(gameObject);
    }
}
