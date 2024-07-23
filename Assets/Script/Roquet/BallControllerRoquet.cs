using UnityEngine;

public class BallControllerRoquet : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        ResetBall();
    }

    public void ResetBall()
    {
        transform.position = new Vector2(0, 4);
        rb.velocity = new Vector2(0, -speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float randomDirection = Random.Range(-1f, 1f);
            Vector2 bounceDirection = new Vector2(randomDirection, 1).normalized;
            rb.velocity = bounceDirection * speed;

            // Воспроизведение звука удара
            audioSource.Play();
        }
        else if (collision.gameObject.tag == "Boundary")
        {
            FindObjectOfType<GameManagerRoquet>().EndGame();
        }
    }
}