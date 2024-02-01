using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private GameObject currentEnemy;
    private float spawnDelay = 2f; 

    void Start()
    {
        SpawnEnemy();
    }

    void Update()
    {
        
        if (currentEnemy == null)
        {
            Invoke("SpawnEnemy", spawnDelay);
        }
    }

    void SpawnEnemy()
    {
        // Instantiate enemy at a random position
        Vector3 spawnPosition = new Vector3(10.71f, Random.Range(-0.71f, -2.51f), 0f);
        currentEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
