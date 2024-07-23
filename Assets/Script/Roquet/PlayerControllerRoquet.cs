using UnityEngine;

public class PlayerControllerRoquet : MonoBehaviour
{
    public float speed = 10f;
    public float minX; // Минимальная координата X
    public float maxX; // Максимальная координата X
    private Vector2 movement;
    private bool moveLeft, moveRight;

    public void OnPointerDownLeft()
    {
        moveLeft = true;
    }

    public void OnPointerDownRight()
    {
        moveRight = true;
    }

    public void OnPointerUp()
    {
        moveLeft = false;
        moveRight = false;
    }

    void Update()
    {
        if (moveLeft)
        {
            movement = new Vector2(-1, 0);
        }
        else if (moveRight)
        {
            movement = new Vector2(1, 0);
        }
        else
        {
            movement = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        Vector2 newPosition = transform.position;
        newPosition += movement * speed * Time.fixedDeltaTime;

        // Ограничение по X координатам
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        transform.position = newPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            FindObjectOfType<GameManagerRoquet>().AddScore();
        }
    }
}