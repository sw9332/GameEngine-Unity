using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class Player3_Run : MonoBehaviour
{
    public Animator Player_motion;
    public float Jump_force = 8f; // 점프에 사용될 힘

    private Rigidbody2D rb;
    private bool isGrounded = true;

    public Slider Hpbar;

    public static float HpCount_Collision;
    public static float HpCount;

    public GameObject GameOver_UI;
    public GameObject Clear_UI;

    public Color blinkColor = Color.red; // 추가: 깜빡이는 색상 설정
    private Color originalColor; // 추가: 원래 색상 저장
    private bool isBlinking = false; // 추가: 깜빡이는 중인지 여부

    public GameObject bullet;
    public Transform bullet_spawn_pos;

    public ParticleSystem Hp_item_effect;

    public AudioSource Jump_sound;

    void Start()
    {
        Player_motion.Play("Player");
        rb = GetComponent<Rigidbody2D>();

        Time.timeScale = 1;

        HpCount_Collision = 10f;
        HpCount = 1.5f;
        Hpbar.value = 100f;

        InvokeRepeating("Hp_Count", 1.2f, 1.2f);

        // 추가: 플레이어의 원래 색상 저장
        originalColor = GetComponent<Renderer>().material.color;

        HP_Effect_Stop();

        Jump_sound.volume = UI_Manager.Audio_value;
    }

    void Update()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (isGrounded && Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        if (transform.position.y < -5f)
        {
            Hpbar.value = 0;
        }

        if (Hpbar.value < 1)
        {
            GameOver();
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Instantiate(bullet, bullet_spawn_pos.position, Quaternion.identity);
        }

        //Hp회복
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            if(UI_Manager.Hp_recovery_item >= 1)
            {
                UI_Manager.Hp_recovery_item--;
                Hpbar.value += 5;
                Hp_item_effect.Play();
                Invoke("HP_Effect_Stop", 1f);
            }
        }
    }

    void HP_Effect_Stop()
    {
        Hp_item_effect.Stop();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "땅")
        {
            Player_motion.Play("Player");
            isGrounded = true;
        }

        if (collision.gameObject.tag == "장애물") // 깜빡이는 중이 아닐 때만 실행
        {
            Hp_Count_Collision();

            // 추가: 장애물과 충돌 시 한 번만 깜빡이기 시작
            StartCoroutine(BlinkPlayer());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "클리어 깃발")
        {
            Clear_UI.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void Jump()
    {
        Player_motion.Play("Player_Jump");
        rb.velocity = new Vector2(rb.velocity.x, Jump_force);
        isGrounded = false;
        Jump_sound.Play();
    }

    void Hp_Count_Collision()
    {
        Hpbar.value -= HpCount_Collision;
    }

    void Hp_Count()
    {
        Hpbar.value -= HpCount;
    }

    void GameOver()
    {
        GameOver_UI.SetActive(true);
        Time.timeScale = 0;
    }

    IEnumerator BlinkPlayer()
    {
        isBlinking = true; // 깜빡이는 중으로 설정

        Renderer renderer = GetComponent<Renderer>();

        for (int i = 0; i < 2; i++) // 깜빡임을 세 번 반복
        {
            renderer.material.color = blinkColor;
            yield return new WaitForSeconds(0.1f);
            renderer.material.color = originalColor;
            yield return new WaitForSeconds(0.1f);
        }

        isBlinking = false; // 깜빡임 종료
    }
}