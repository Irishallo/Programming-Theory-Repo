using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    private float xSpawn = 115.0f;
    private float zSpawnTop = -55.0f;
    private float zSpawnBottom = -90.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        int leftRight = Random.Range(0, 2);
        if(leftRight == 0)
        {
            Vector3 spawnPos = new Vector3(xSpawn, 0, Random.Range(zSpawnTop, zSpawnBottom));
            Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
        } else
        {
            Vector3 spawnPos = new Vector3(-xSpawn, 0, Random.Range(zSpawnTop, zSpawnBottom));
            Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
        }
        
    }
}
