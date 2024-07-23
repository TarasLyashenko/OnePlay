using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public float resetPositionY = -10f; // Y-позиция, при которой фон будет сброшен наверх
    public float startPositionY = 10f; // Начальная Y-позиция фона, после сброса

    void Update()
    {
        transform.Translate(Vector2.down * scrollSpeed * Time.deltaTime);

        if (transform.position.y <= resetPositionY)
        {
            ResetPosition();
        }
    }

    void ResetPosition()
    {
        transform.position = new Vector2(transform.position.x, startPositionY);
    }
}