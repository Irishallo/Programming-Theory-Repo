using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs; //ENCAPSULATION
    [SerializeField] GameObject[] goodItemPrefabs; //ENCAPSULATION
    [SerializeField] GameObject gameOverScreen; //ENCAPSULATION
    [SerializeField] GameObject titleScreen; //ENCAPSULATION
    private float xSpawn = 115.0f; //ENCAPSULATION
    private float zSpawn1 = -55.0f; //ENCAPSULATION
    private float zSpawn2 = -90.0f; //ENCAPSULATION
    private float zSpawn3 = 45.0f; //ENCAPSULATION
    private float zSpawn4 = -45.0f; //ENCAPSULATION
    private float startDelayEnemy = 2; //ENCAPSULATION
    private float enemySpawnInterval = 1.5f; //ENCAPSULATION
    private float startDelayGood = 7; //ENCAPSULATION
    private float goodSpawnInterval = 5f; //ENCAPSULATION
    public bool gameActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnemy() //ABSTRACTION
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

    private void SpawnGoodItems() //ABSTRACTION
    {
        if(gameActive)
        {
            int goodItemIndex = Random.Range(0, goodItemPrefabs.Length);
            Vector3 spawnPosGood = new Vector3(Random.Range(-xSpawn, xSpawn), 0, Random.Range(zSpawn4, zSpawn3));
            Instantiate(goodItemPrefabs[goodItemIndex], spawnPosGood, goodItemPrefabs[goodItemIndex].transform.rotation);
        }
    }

    public void GameOver() //ABSTRACTION
    {
        gameOverScreen.gameObject.SetActive(true);
        gameActive = false;
    }

    public void StartGame() //ABSTRACTION
    {
        gameActive = true;
        titleScreen.gameObject.SetActive(false);
        InvokeRepeating("SpawnEnemy", startDelayEnemy, enemySpawnInterval);
        InvokeRepeating("SpawnGoodItems", startDelayGood, goodSpawnInterval);
    }

    public void RestartGame() //ABSTRACTION
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
