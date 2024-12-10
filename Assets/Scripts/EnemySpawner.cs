using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Assign the prefab in the Inspector
    public float spawnInterval = 2f; // Spawn every 2 seconds
    public float spawnRangeX = 5f; // Random horizontal range for spawning
    public Vector2[] predefinedSpawnPoints; // Array of predefined spawn points

    private int currentSpawnPointIndex = 0; // To cycle through predefined points

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Vector2 spawnPosition;

            if (predefinedSpawnPoints.Length > 0 && Random.value > 0.5f) // 50% chance for predefined or random
            {
                // Use the next predefined spawn point
                spawnPosition = predefinedSpawnPoints[currentSpawnPointIndex];
                currentSpawnPointIndex = (currentSpawnPointIndex + 1) % predefinedSpawnPoints.Length; // Cycle to the next
            }
            else
            {
                // Calculate a random spawn position
                float randomX = Random.Range(-spawnRangeX, spawnRangeX);
                spawnPosition = new Vector2(randomX, Camera.main.orthographicSize + 1);
            }

            Debug.Log("Spawning enemy at: " + spawnPosition); // Debug message

            // Spawn the enemy
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval); // Wait for the next spawn
        }
    }
}
