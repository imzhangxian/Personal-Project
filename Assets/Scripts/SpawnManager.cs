using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    // public GameObject bulletPrefab;
    private float startDelay = 3f;
    private float spawnInterval = 3f;
    private float xSpawnBound = 15f;
    private float zSpawnBound = 15f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnemies()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[enemyIndex], GetSpawnPosition(), enemyPrefabs[enemyIndex].transform.rotation);
    }

    private Vector3 GetSpawnPosition()
    {
        float xSpawn = Random.Range(- xSpawnBound, 0);
        float zSpawn = Random.Range(- zSpawnBound, zSpawnBound);
        return new Vector3(xSpawn, 1, zSpawn);
    }
}
