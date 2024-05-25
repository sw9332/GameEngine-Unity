using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public float targetX = 5f; // 목표 x 좌표
    public float moveSpeed = 2f; // 보스의 이동 속도

    public Transform weapon1_spawn_pos;
    public Animator weapon1_An;
    public GameObject weapon1;

    public Animator weapon1_2_An;
    
    public ParticleSystem p;

    public Slider Hp;

    void Start()
    {
        weapon1_An.speed = 0;
        weapon1_2_An.speed = 0;

        Hp.value = 100;

        Invoke("Boss_move1", 2f);

        InvokeRepeating("Boss_weapon1", 4.5f, 1.5f);
        Invoke("Invoke_Delete1", 11.3f);

        Invoke("Boss_weapon1_2", 13.5f);
        Invoke("Invoke_Delete1_2", 16.8f);

        InvokeRepeating("Boss_weapon2", 20f, 1.5f);
        //Invoke("Invoke_Delete2", 25.4f);
    }

    void Update()
    {
        if(Hp.value < 1)
        {
            SceneManager.LoadScene("Stage3_Clear");
        }
    }

    void Boss_move1()
    {
        StartCoroutine(MoveToPosition(new Vector2(targetX, transform.position.y), moveSpeed));
    }

    IEnumerator MoveToPosition(Vector2 targetPosition, float speed)
    {
        while (Mathf.Abs(transform.position.x - targetPosition.x) > 0.01f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            Hp.value -= 0.28f;
            p.Play();
        }
    }

//------------------------------------

    void Boss_weapon1()
    {
        weapon1_An.speed = 1;
        Instantiate(weapon1, weapon1_spawn_pos.position, Quaternion.identity);
    }
     
    void Invoke_Delete1()
    {
        CancelInvoke("Boss_weapon1");
        weapon1_An.speed = 0;
    }

    void Boss_weapon2()
    {
        weapon1_An.speed = 1;
        Instantiate(weapon1, weapon1_spawn_pos.position, Quaternion.identity);
    }
     
    void Invoke_Delete2()
    {
        CancelInvoke("Boss_weapon2");
        weapon1_An.speed = 0;
    }

//--------------------------------------

    void Boss_weapon1_2()
    {
        weapon1_2_An.speed = 1;
    }

    void Invoke_Delete1_2()
    {
        CancelInvoke("Boss_weapon1_2");
        weapon1_2_An.speed = 0;
    }
}