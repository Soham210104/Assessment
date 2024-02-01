using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBotSpawner : MonoBehaviour
{
    public GameObject GroundBot;
    private float spawnInterval = 15f; // Set the time interval between instantiations

    void Start()
    {
        // Start invoking the SpawnPrefab method every spawnInterval seconds
        InvokeRepeating("SpawnPrefab", 0f, spawnInterval);
    }

    void SpawnPrefab()
    {
        // Instantiate the prefab at the current position
        Instantiate(GroundBot, transform.position, Quaternion.identity);
    }
}
