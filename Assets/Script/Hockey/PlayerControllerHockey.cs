using UnityEngine;

public class PlayerControllerHockey : MonoBehaviour
{
    public float speed = 10f;
    public float minX = -2.2f;
    public float maxX = 2.2f;
    private Vector2 movement;
    private Rigidbody2D rb;
    private bool isMovingLeft;
    private bool isMovingRight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isMovingLeft)
        {
            movement = Vector2.left * speed;
        }
        else if (isMovingRight)
        {
            movement = Vector2.right * speed;
        }
        else
        {
            movement = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = movement;

        // Ограничение движения по X
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        transform.position = clampedPosition;
    }

    public void MoveLeft()
    {
        isMovingLeft = true;
        isMovingRight = false;
    }

    public void MoveRight()
    {
        isMovingRight = true;
        isMovingLeft = false;
    }

    public void StopMoving()
    {
        isMovingLeft = false;
        isMovingRight = false;
    }
}