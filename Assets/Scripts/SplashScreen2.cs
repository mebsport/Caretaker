using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreen2 : MonoBehaviour
{
    public Text splashText2;

    IEnumerator Start()
    {
        splashText2.canvasRenderer.SetAlpha(0.0f);

        new WaitForSeconds(2.5f);

        FadeIn2();
        yield return new WaitForSeconds(2.5f);

        FadeOut2();
        yield return new WaitForSeconds(2.5f);

        SceneManager.LoadScene("SplashScreen");
    }

    void FadeIn2()
    {
        splashText2.CrossFadeAlpha(1.0f, 1.5f, false);
    }

    void FadeOut2()
    {
        splashText2.CrossFadeAlpha(0.0f, 2.5f, false);
    }
}
