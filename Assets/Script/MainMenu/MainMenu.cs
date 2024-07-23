using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadTennisGame()
    {
        SceneManager.LoadScene("RoqkuetScene");
    }

    public void LoadFootballGame()
    {
        SceneManager.LoadScene("FootballScene");
    }

    public void LoadHockeyGame()
    {
        SceneManager.LoadScene("HockeyScene");
    }

    public void LoadQuiz()
    {
        SceneManager.LoadScene("QuizGame");
    }

    public void LoadFact()
    {
        SceneManager.LoadScene("FactScene");
    }

    public void LoadStatistics()
    {
        SceneManager.LoadScene("StatistickScene");
    }



    public void QuitGame()
    {
        Application.Quit();
    }
}
