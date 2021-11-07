using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : EnemyController //INHERITANCE
{
    private float enemy3Speed = 25; //ENCAPSULATION
    private float shootSpeed3 = 1; //ENCAPSULATION
    private SpawnManager spawnManager; //ENCAPSULATION
    private PlayerController playerController; //ENCAPSULATION
    [SerializeField] GameObject item3; //ENCAPSULATION

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
        ShootItem(item3, shootSpeed3);

        if (movingLeft)
        {
            MoveEnemyLeft(enemy3Speed);
        }
        else if (movingRight)
        {
            MoveEnemyRight(enemy3Speed);
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
