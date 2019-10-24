using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public Text splashText;

    IEnumerator Start()
    {
        splashText.canvasRenderer.SetAlpha(0.0f);

        FadeIn();
        yield return new WaitForSeconds(2.5f);

        FadeOut();
        yield return new WaitForSeconds(3.0f);

        SceneManager.LoadScene("MainMenu");
    }

    void FadeIn()
    {
        splashText.CrossFadeAlpha(1.0f, 1.5f, false);
    }

    void FadeOut()
    {
        splashText.CrossFadeAlpha(0.0f, 2.5f, false);
    }
}
