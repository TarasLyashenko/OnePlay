using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public float resetPositionY = -10f; // Y-�������, ��� ������� ��� ����� ������� ������
    public float startPositionY = 10f; // ��������� Y-������� ����, ����� ������

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