using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    [System.Serializable]
    public class Question
    {
        public string questionText;
        public bool isCorrect;
    }

    public TMP_Text questionText;
    public Button rightButton;
    public Button wrongButton;
    public TMP_Text resultText;
    public Button nextButton;

    public Question[] questions;
    private int currentQuestionIndex;

    // Статические переменные для хранения результатов
    public static int correctAnswersCount;
    public static int incorrectAnswersCount;

    void Start()
    {
        currentQuestionIndex = 0;
        correctAnswersCount = 0;
        incorrectAnswersCount = 0;
        LoadQuestion();
        rightButton.onClick.AddListener(() => AnswerSelected(true));
        wrongButton.onClick.AddListener(() => AnswerSelected(false));
        nextButton.onClick.AddListener(NextQuestion);
    }

    void LoadQuestion()
    {
        if (currentQuestionIndex < questions.Length)
        {
            Question currentQuestion = questions[currentQuestionIndex];
            questionText.text = currentQuestion.questionText;
            resultText.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(false);
            rightButton.gameObject.SetActive(true);
            wrongButton.gameObject.SetActive(true);
        }
        else
        {
            EndQuiz();
        }
    }

    void AnswerSelected(bool answer)
    {
        rightButton.gameObject.SetActive(false);
        wrongButton.gameObject.SetActive(false);
        resultText.gameObject.SetActive(true);

        if (answer == questions[currentQuestionIndex].isCorrect)
        {
            resultText.text = "RIGHT!";
            resultText.color = Color.green;
            correctAnswersCount++;
        }
        else
        {
            resultText.text = "WRONG!";
            resultText.color = Color.red;
            incorrectAnswersCount++;
        }

        nextButton.gameObject.SetActive(true);
    }

    void NextQuestion()
    {
        currentQuestionIndex++;
        LoadQuestion();
    }

    void EndQuiz()
    {
        questionText.text = "Quiz Over!\nCorrect Answers: " + correctAnswersCount + "\nIncorrect Answers: " + incorrectAnswersCount;
        rightButton.gameObject.SetActive(false);
        wrongButton.gameObject.SetActive(false);
        resultText.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}