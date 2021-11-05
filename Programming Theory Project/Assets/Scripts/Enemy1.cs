using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : EnemyController
{
    private float enemy1Speed = 15;
    private float shootSpeed1 = 1;
    private SpawnManager spawnManager;
    [SerializeField] GameObject item1;

    // Start is called before the first frame update
    public override void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        if (transform.position.x == xPos)
        {
            movingLeft = true;
        } else if(transform.position.x == -xPos)
        {
            movingRight = true;
        }

        shootingOk = true;
    }

    // Update is called once per frame
    public override void Update()
    {
        ShootItem(item1, shootSpeed1);

        if(movingLeft)
        {
            MoveEnemyLeft(enemy1Speed);
        } else if(movingRight)
        {
            MoveEnemyRight(enemy1Speed);
        }

        if(transform.position.x < -xBounds || transform.position.x > xBounds || !spawnManager.gameActive)
        {
            RemoveEnemy();
        }
        
    }
}
