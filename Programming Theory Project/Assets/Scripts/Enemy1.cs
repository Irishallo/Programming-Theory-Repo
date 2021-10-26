using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : EnemyController
{
    private float enemy1Speed = 15;

    // Start is called before the first frame update
    public override void Start()
    {
        if(transform.position.x == xPos)
        {
            movingLeft = true;
        } else if(transform.position.x == -xPos)
        {
            movingRight = true;
        }
        
    }

    // Update is called once per frame
    public override void Update()
    {
        if(movingLeft)
        {
            MoveEnemyLeft(enemy1Speed);
        } else if(movingRight)
        {
            MoveEnemyRight(enemy1Speed);
        }

        if(transform.position.x < -xBounds || transform.position.x > xBounds)
        {
            RemoveEnemy();
        }
        
    }
}
