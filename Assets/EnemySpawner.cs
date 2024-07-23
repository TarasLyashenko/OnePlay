using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // ������ �������� ������
    public float minX;
    public float maxX;
    public float spawnIntervalMin = 3f; // ����������� �������� ������
    public float spawnIntervalMax = 5f; // ������������ �������� ������
    private float spawnTimer;

    void Start()
    {
        SetNextSpawnTime(); // ������������� ����� �� ���������� ������
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            SpawnEnemy();
            SetNextSpawnTime(); // ������������� ����� �� ���������� ������
        }
    }

    void SpawnEnemy()
    {
        int spawnPattern = Random.Range(2, 4); // ��������� ���������� ������ � ���� (2 ��� 3)
        float startX = Random.Range(minX, maxX - (spawnPattern - 1));
        for (int i = 0; i < spawnPattern; i++)
        {
            float xPos = startX + i;
            int randomIndex = Random.Range(0, enemyPrefabs.Length); // ��������� ����� �����
            Instantiate(enemyPrefabs[randomIndex], new Vector2(xPos, 5), Quaternion.identity);
        }
    }

    void SetNextSpawnTime()
    {
        spawnTimer = Random.Range(spawnIntervalMin, spawnIntervalMax);
    }
}