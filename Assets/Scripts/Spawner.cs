using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Collectibles; // Array of collectible prefabs to spawn
    public int numberOfCollectibles = 3; // Number of each collectible to spawn
    public Vector3 spawnAreaSize = new Vector3(10, 1, 10); // Area size for spawning collectibles

    private void Start()
    {
        SpawnCollectibles();
    }

    private void SpawnCollectibles()
    {
        for (int i = 0; i < numberOfCollectibles; i++)
        {
            foreach (GameObject collectible in Collectibles)
            {
                // Generate a random position within the spawn area, offset from the Spawner's position
                Vector3 randomPosition = new Vector3(
                    Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                    spawnAreaSize.y, // Fixed height
                    Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
                ) + transform.position;

                // Spawn the collectible at the random position
                Instantiate(collectible, randomPosition, Quaternion.identity);
            }
        }
    }
}