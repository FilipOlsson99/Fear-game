using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{

    public Image fadeInUIImage;
    public float fadeSpeed = 2f;

    public string nextScene;

    public float delay = 0.1f;

    public bool fadeOut = false;

    private void OnEnable()
    {
        StartCoroutine(FadeDelay());
    }

    private IEnumerator FadeDelay()
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(fadeOut ? FadeOut() : FadeIn());
    }

    private IEnumerator FadeOut()
    {
        float alpha = 0;
        float fadeEndValue = 1;
        while (alpha < fadeEndValue)
        {
            alpha += Time.deltaTime * (1.0f / fadeSpeed);
            fadeInUIImage.enabled = true;
            SetColorImage(alpha);
            yield return null;

            if (alpha >= fadeEndValue)
            {
                SceneManager.LoadScene(nextScene);
                Debug.Log("Loaded scene");
            }
        }
    }

    private IEnumerator FadeIn()
    {
        float alpha = 1;
        float fadeEndValue = 0;
        while (alpha > fadeEndValue)
        {
            alpha -= Time.deltaTime * (1.0f / fadeSpeed);
            fadeInUIImage.enabled = true;
            SetColorImage(alpha);
            yield return null;

            if (alpha <= fadeEndValue)
            {
                fadeInUIImage.enabled = false;
            }
        }


    }

    private void SetColorImage(float alpha)
    {
        fadeInUIImage.color = new Color(fadeInUIImage.color.r, fadeInUIImage.color.g, fadeInUIImage.color.b, alpha);
    }


}
