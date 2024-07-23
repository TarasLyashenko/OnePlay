using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 0.5f; // ���������� ��������� �������� ��� �������� ��������

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject != null)
        {
            if (collision.tag == "Boundary")
            {
                FindObjectOfType<GameManagerFootball>().AddScore();
                Destroy(gameObject); // ������� ����� ��� ���������� ������ �������
            }
            else if (collision.tag == "Player")
            {
                FindObjectOfType<GameManagerFootball>().SubtractScore();
                Destroy(gameObject); // ������� ����� ��� ������������ � �������
            }
        }
    }
}