using UnityEngine;

public class PauseMenuFootball : MonoBehaviour
{
    public void Resume()
    {
        FindObjectOfType<GameManagerFootball>().PauseGame();
    }

    public void Exit()
    {
        FindObjectOfType<GameManagerFootball>().ReturnToMenu();
    }
}