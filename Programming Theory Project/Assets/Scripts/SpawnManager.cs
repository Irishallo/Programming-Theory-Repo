using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] GameObject[] goodItemPrefabs;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject titleScreen;
    private float xSpawn = 115.0f;
    private float zSpawn1 = -55.0f;
    private float zSpawn2 = -90.0f;
    private float zSpawn3 = 45.0f;
    private float zSpawn4 = -45.0f;
    private float startDelayEnemy = 2;
    private float enemySpawnInterval = 1.5f;
    private float startDelayGood = 7;
    private float goodSpawnInterval = 5f;
    public bool gameActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnemy()
    {
        if(gameActive)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            int leftRight = Random.Range(0, 2);
            if (leftRight == 0)
            {
                Vector3 spawnPos = new Vector3(xSpawn, 0, Random.Range(zSpawn1, zSpawn2));
                Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
            }
            else
            {
                Vector3 spawnPos = new Vector3(-xSpawn, 0, Random.Range(zSpawn1, zSpawn2));
                Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
            }
        }
    }

    private void SpawnGoodItems()
    {
        if(gameActive)
        {
            int goodItemIndex = Random.Range(0, goodItemPrefabs.Length);
            Vector3 spawnPosGood = new Vector3(Random.Range(-xSpawn, xSpawn), 0, Random.Range(zSpawn4, zSpawn3));
            Instantiate(goodItemPrefabs[goodItemIndex], spawnPosGood, goodItemPrefabs[goodItemIndex].transform.rotation);
        }
    }

    public void GameOver()
    {
        gameOverScreen.gameObject.SetActive(true);
        gameActive = false;
    }

    public void StartGame()
    {
        gameActive = true;
        titleScreen.gameObject.SetActive(false);
        InvokeRepeating("SpawnEnemy", startDelayEnemy, enemySpawnInterval);
        InvokeRepeating("SpawnGoodItems", startDelayGood, goodSpawnInterval);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
