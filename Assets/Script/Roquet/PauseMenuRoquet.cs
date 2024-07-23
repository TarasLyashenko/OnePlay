using UnityEngine;

public class PauseMenuRoquet : MonoBehaviour
{
    public void Resume()
    {
        FindObjectOfType<GameManagerRoquet>().PauseGame();
    }

    public void Exit()
    {
        FindObjectOfType<GameManagerRoquet>().ReturnToMenu();
    }
}