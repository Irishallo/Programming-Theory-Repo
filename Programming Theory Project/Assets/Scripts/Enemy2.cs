using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : EnemyController
{
    private float enemy2Speed = 20;

    // Start is called before the first frame update
    public override void Start()
    {
        if (transform.position.x == xPos)
        {
            movingLeft = true;
        }
        else if (transform.position.x == -xPos)
        {
            movingRight = true;
        }

    }

    // Update is called once per frame
    public override void Update()
    {
        if (movingLeft)
        {
            MoveEnemyLeft(enemy2Speed);
        }
        else if (movingRight)
        {
            MoveEnemyRight(enemy2Speed);
        }

        if (transform.position.x < -xBounds || transform.position.x > xBounds)
        {
            RemoveEnemy();
        }

    }
}
