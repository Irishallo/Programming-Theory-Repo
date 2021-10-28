using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] GameObject[] goodItemPrefabs;
    private float xSpawn = 115.0f;
    private float zSpawn1 = -55.0f;
    private float zSpawn2 = -90.0f;
    private float zSpawn3 = 45.0f;
    private float startDelayEnemy = 2;
    private float enemySpawnInterval = 1.5f;
    private float startDelayGood = 7;
    private float goodSpawnInterval = 5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelayEnemy, enemySpawnInterval);
        InvokeRepeating("SpawnGoodItems", startDelayGood, goodSpawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        int leftRight = Random.Range(0, 2);
        if(leftRight == 0)
        {
            Vector3 spawnPos = new Vector3(xSpawn, 0, Random.Range(zSpawn1, zSpawn2));
            Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
        } else
        {
            Vector3 spawnPos = new Vector3(-xSpawn, 0, Random.Range(zSpawn1, zSpawn2));
            Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
        }
        
    }

    private void SpawnGoodItems()
    {
        int goodItemIndex = Random.Range(0, goodItemPrefabs.Length);
        Vector3 spawnPosGood = new Vector3(Random.Range(-xSpawn, xSpawn), 0, Random.Range(zSpawn1, zSpawn3));
        Instantiate(goodItemPrefabs[goodItemIndex], spawnPosGood, goodItemPrefabs[goodItemIndex].transform.rotation);
    }
}
