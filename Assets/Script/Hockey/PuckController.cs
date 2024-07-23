using UnityEngine;

public class PuckController : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameManagerHockey gameManager;
    public float constantSpeed = 5f; // Постоянная скорость шайбы
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManagerHockey>();
        audioSource = GetComponent<AudioSource>();
        SetInitialVelocity();
    }

    void SetInitialVelocity()
    {
        // Устанавливаем начальную скорость шайбы
        rb.velocity = Vector2.down * constantSpeed;
    }

    void FixedUpdate()
    {
        // Поддерживаем постоянную скорость шайбы
        rb.velocity = rb.velocity.normalized * constantSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Добавляем небольшой случайный компонент к вектору направления
            float randomX = Random.Range(-1f, 1f);
            Vector2 direction = new Vector2(randomX, 1).normalized;
            rb.velocity = direction * constantSpeed;
            PlayHitSound();
        }
        else if (collision.gameObject.CompareTag("Boundary"))
        {
            // Добавляем небольшой случайный компонент к вектору направления при столкновении с боковой границей
            float randomX = Random.Range(-1f, 1f);
            Vector2 upwardBounce = new Vector2(randomX, 1).normalized;
            rb.velocity = upwardBounce * constantSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            gameManager.ScoreGoal();
        }
        else if (other.gameObject.CompareTag("BottomBoundary"))
        {
            PlayBottomBoundarySound(other.gameObject);
            gameManager.SubtractScore();
            gameManager.ResetPuckPosition();
            SetInitialVelocity(); // Устанавливаем начальную скорость
        }
        else if (other.gameObject.CompareTag("TopBoundary"))
        {
            gameManager.ResetPuckPosition();
            SetInitialVelocity(); // Устанавливаем начальную скорость
        }
    }

    void PlayHitSound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    void PlayBottomBoundarySound(GameObject boundary)
    {
        AudioSource boundaryAudioSource = boundary.GetComponent<AudioSource>();
        if (boundaryAudioSource != null)
        {
            boundaryAudioSource.Play();
        }
    }
}