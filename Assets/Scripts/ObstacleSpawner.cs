using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform ball;
    public GameObject[] obstaclePrefabs;
    public float spawnDistance = 5f;
    public float verticalOffset = 1f;
    public int obstaclesPerSpawn = 1;
    private float lastSpawnY;

    void Start()
    {
        lastSpawnY = ball.position.y;
    }

    void Update()
    {
        if (ball.position.y < lastSpawnY - spawnDistance)
        {
            SpawnObstacles();
            lastSpawnY = ball.position.y;
        }
    }

    void SpawnObstacles()
    {
        for (int i = 0; i < obstaclesPerSpawn; i++)
        {
            GameObject prefabSeleccionado = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

            Vector3 spawnPosition = new Vector3(
                transform.position.x,
                ball.position.y - verticalOffset,
                transform.position.z
            );

            Instantiate(prefabSeleccionado, spawnPosition, Quaternion.identity, transform);
        }
    }
}
