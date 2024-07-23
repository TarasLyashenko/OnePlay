using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Массив префабов врагов
    public float minX;
    public float maxX;
    public float spawnIntervalMin = 3f; // Минимальный интервал спавна
    public float spawnIntervalMax = 5f; // Максимальный интервал спавна
    private float spawnTimer;

    void Start()
    {
        SetNextSpawnTime(); // Устанавливаем время до следующего спавна
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            SpawnEnemy();
            SetNextSpawnTime(); // Устанавливаем время до следующего спавна
        }
    }

    void SpawnEnemy()
    {
        int spawnPattern = Random.Range(2, 4); // Случайное количество врагов в ряду (2 или 3)
        float startX = Random.Range(minX, maxX - (spawnPattern - 1));
        for (int i = 0; i < spawnPattern; i++)
        {
            float xPos = startX + i;
            int randomIndex = Random.Range(0, enemyPrefabs.Length); // Случайный выбор врага
            Instantiate(enemyPrefabs[randomIndex], new Vector2(xPos, 5), Quaternion.identity);
        }
    }

    void SetNextSpawnTime()
    {
        spawnTimer = Random.Range(spawnIntervalMin, spawnIntervalMax);
    }
}