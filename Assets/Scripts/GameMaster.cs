using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public Text score;

    private string scoreValue;

    private bool hasLost;

    public GameObject restartPanel;

    private void Start()
    {

    }
    private void Update()
    {
        if(hasLost == false)
        {
            scoreValue = Time.timeSinceLevelLoad.ToString("F0");
            score.text = scoreValue;
        }
    }
    public void GameOver()
    {
        hasLost = true;
        restartPanel.SetActive(true);
    }
    public void GoToGameMenu()
    {
        SceneManager.LoadScene("Menu2");
    }
    public void GoToHelpPage()
    {
        SceneManager.LoadScene("Help");
    }
    public void EndlessMode()
    {
        SceneManager.LoadScene("Endless");
    }
    public void SurvivalMode()
    {
        SceneManager.LoadScene("Survival");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    public void AboutPage()
    {
        SceneManager.LoadScene("About");
    }
    public void OpenPrivacyPolicy()
    {
        Application.OpenURL("https://medium.com/@adventitious.studios/caretaker-privacy-4fda331620af");
    }
}
