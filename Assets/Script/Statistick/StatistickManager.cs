using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StatistickManager : MonoBehaviour
{
    public TMP_Text correctAnswersText;
    public TMP_Text wrongAnswersText;

    void Start()
    {
        UpdateStatistics();
    }

    void UpdateStatistics()
    {
        correctAnswersText.text = "Correct Answers: " + QuizManager.correctAnswersCount;
        wrongAnswersText.text = "Wrong Answers: " + QuizManager.incorrectAnswersCount;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}