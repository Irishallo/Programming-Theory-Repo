using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : EnemyController
{
    private float enemy3Speed = 25;

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
            MoveEnemyLeft(enemy3Speed);
        }
        else if (movingRight)
        {
            MoveEnemyRight(enemy3Speed);
        }

        if (transform.position.x < -xBounds || transform.position.x > xBounds)
        {
            RemoveEnemy();
        }

    }
}
