using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerRoquet : MonoBehaviour
{
    public GameObject startButton;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public TMP_Text scoreText;
    public TMP_Text finalScoreText;
    public GameObject player;
    public GameObject ball;
    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject pauseButton;
    public GameObject resumeButton;
    public GameObject exitButton;
    public GameObject restartButton;
    public GameObject mainMenuButton;
    private AudioSource audioSource; 

    private int score = 0;
    private bool isGamePaused = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // »нициализаци€ AudioSource
        audioSource.Play(); // ¬оспроизведение фонового звука при старте
        ShowStartMenu();
    }

    public void ShowStartMenu()
    {
        startButton.SetActive(true);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        player.SetActive(false);
        ball.SetActive(false);
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
        ball.SetActive(true);
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
    }

    public void PauseGame()
    {
        isGamePaused = !isGamePaused;
        pauseMenu.SetActive(isGamePaused);
        resumeButton.SetActive(isGamePaused);
        exitButton.SetActive(isGamePaused);
        player.SetActive(!isGamePaused);
        ball.SetActive(!isGamePaused);
        leftButton.SetActive(!isGamePaused);
        rightButton.SetActive(!isGamePaused);
        pauseButton.SetActive(!isGamePaused);
        scoreText.gameObject.SetActive(!isGamePaused);
        Time.timeScale = isGamePaused ? 0f : 1f;

        if (isGamePaused)
        {
            audioSource.Pause(); // ќстановка фонового звука при паузе
        }
        else
        {
            audioSource.Play(); // ¬озобновление фонового звука при продолжении игры
        }
    }

    public void EndGame()
    {
        gameOverMenu.SetActive(true);
        finalScoreText.text = "Score: " + score;
        player.SetActive(false);
        ball.SetActive(false);
        leftButton.SetActive(false);
        rightButton.SetActive(false);
        pauseButton.SetActive(false);
        scoreText.gameObject.SetActive(false);
        restartButton.SetActive(true);
        mainMenuButton.SetActive(true);
        Time.timeScale = 0f;
        audioSource.Stop(); // ќстановка фонового звука при окончании игры
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
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}