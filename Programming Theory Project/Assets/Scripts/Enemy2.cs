using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : EnemyController //INHERITANCE
{
    private float enemy2Speed = 20; //ENCAPSULATION
    private float shootSpeed2 = 2; //ENCAPSULATION
    private SpawnManager spawnManager; //ENCAPSULATION
    private PlayerController playerController; //ENCAPSULATION
    [SerializeField] GameObject item2; //ENCAPSULATION

    // Start is called before the first frame update
    public override void Start() //POLYMORPHISM
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        if (transform.position.x == xPos)
        {
            movingLeft = true;
        }
        else if (transform.position.x == -xPos)
        {
            movingRight = true;
        }

        shootingOk = true;
    }

    // Update is called once per frame
    public override void Update() //POLYMORPHISM
    {
        ShootItem(item2, shootSpeed2);

        if (movingLeft)
        {
            MoveEnemyLeft(enemy2Speed);
        }
        else if (movingRight)
        {
            MoveEnemyRight(enemy2Speed);
        }

        if (!spawnManager.gameActive)
        {
            RemoveEnemy();
        }
        else if (transform.position.x < -xBounds || transform.position.x > xBounds)
        {
            playerController.ScoreUpdate();
            RemoveEnemy();
        }

    }
}
