using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameManagerHockey : MonoBehaviour
{
    public GameObject startButton;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public TMP_Text scoreText;
    public TMP_Text finalScoreText;
    public GameObject player;
    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject pauseButton;
    public GameObject resumeButton;
    public GameObject exitButton;
    public GameObject restartButton;
    public GameObject mainMenuButton;
    public GameObject puck;
    public Transform puckStartPosition;
    public AudioClip goalSound;
    private AudioSource audioSource;

    private int score = 0;
    private bool isGamePaused = false;
    public float puckInitialSpeed = 5f; // ��������� �������� �����

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ShowStartMenu();
    }

    public void ShowStartMenu()
    {
        startButton.SetActive(true);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        player.SetActive(false);
        leftButton.SetActive(false);
        rightButton.SetActive(false);
        pauseButton.SetActive(false);
        scoreText.gameObject.SetActive(false);
        resumeButton.SetActive(false);
        exitButton.SetActive(false);
        restartButton.SetActive(false);
        mainMenuButton.SetActive(false);
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        startButton.SetActive(false);
        player.SetActive(true);
        leftButton.SetActive(true);
        rightButton.SetActive(true);
        pauseButton.SetActive(true);
        scoreText.gameObject.SetActive(true);
        resumeButton.SetActive(false);
        exitButton.SetActive(false);
        restartButton.SetActive(false);
        mainMenuButton.SetActive(false);
        score = 0;
        UpdateScore();
        Time.timeScale = 1f;
        audioSource.Play(); // �������� ��������������� �������� �����
    }

    public void PauseGame()
    {
        isGamePaused = !isGamePaused;
        pauseMenu.SetActive(isGamePaused);
        resumeButton.SetActive(isGamePaused);
        exitButton.SetActive(isGamePaused);
        player.SetActive(!isGamePaused);
        leftButton.SetActive(!isGamePaused);
        rightButton.SetActive(!isGamePaused);
        pauseButton.SetActive(!isGamePaused);
        scoreText.gameObject.SetActive(!isGamePaused);
        puck.SetActive(!isGamePaused); // ������ ��� �������� �����
        Time.timeScale = isGamePaused ? 0f : 1f;

        if (isGamePaused)
        {
            audioSource.Pause(); // ������������� ������� ����
            HideEnemies();
        }
        else
        {
            audioSource.Play(); // ������������ ������� ����
            ShowEnemies();
            ResumePuckMovement(); // ������������ �������� ����� ����� �����
        }
    }

    public void EndGame(bool won)
    {
        gameOverMenu.SetActive(true);
        finalScoreText.text = won ? "You Win!" : "You Lose";
        player.SetActive(false);
        leftButton.SetActive(false);
        rightButton.SetActive(false);
        pauseButton.SetActive(false);
        scoreText.gameObject.SetActive(false);
        restartButton.SetActive(true);
        mainMenuButton.SetActive(true);
        HideEnemies(); // �������� ������
        Time.timeScale = 0f;
        audioSource.Stop(); // ������������� ������� ����
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void AddScore()
    {
        score++;
        UpdateScore();
        CheckWinCondition();
    }

    public void SubtractScore()
    {
        score--;
        UpdateScore();
        CheckLoseCondition();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    void CheckWinCondition()
    {
        if (score >= 20)
        {
            EndGame(true);
        }
    }

    void CheckLoseCondition()
    {
        if (score <= -10)
        {
            EndGame(false);
        }
    }

    void HideEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(false);
        }
    }

    void ShowEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(true);
        }
    }

    public void ScoreGoal()
    {
        AddScore();
        audioSource.PlayOneShot(goalSound);
        ResetPuckPosition();
    }

    public void ResetPuckPosition()
    {
        puck.transform.position = puckStartPosition.position;
        Rigidbody2D rb = puck.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero; // ���������� �������� �����
            rb.velocity = Vector2.down * puckInitialSpeed; // ������������� ��������� �������� ����� ����
        }
    }

    public void ResumePuckMovement()
    {
        Rigidbody2D rb = puck.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.down * puckInitialSpeed; // ������������� ��������� �������� ����� ����
        }
    }
}