using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTimeManager : MonoBehaviour
{
    public Animator Boss_Animation;
    public GameObject An2;
    public GameObject An3;
    public GameObject An4;
    public GameObject An5;

    public Image fadeImage;
    public float fadeDuration = 1.5f;

    IEnumerator Start()
    {
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0f);

        yield return new WaitForSeconds(5);
        BossDieAnimation2();

        yield return new WaitForSeconds(8 - 5);
        BossDieAnimation3();

        yield return new WaitForSeconds(9 - 8);
        BossDieAnimation4();

        yield return new WaitForSeconds(9.5f - 9);
        BossDieAnimation5();

        yield return new WaitForSeconds(12 - 8);
        StartCoroutine(FadeOut());

        yield return new WaitForSeconds(15.5f - 12);
        SceneChange();
    }

    //페이드아웃
    IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color color = fadeImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }
    }

    void BossDieAnimation1()
    {
        Boss_Animation.Play("Boss_Die");
    }

    void BossDieAnimation2()
    {
        Boss_Animation.Play("Boss_Die2");
        An2.SetActive(true);
    }

    void BossDieAnimation3()
    {
        An3.SetActive(true);
    }

    void BossDieAnimation4()
    {
        An3.SetActive(true);
    }

    void BossDieAnimation5()
    {
        An3.SetActive(true);
    }

    void SceneChange()
    {
        SceneManager.LoadScene("LastScene");
    }
}