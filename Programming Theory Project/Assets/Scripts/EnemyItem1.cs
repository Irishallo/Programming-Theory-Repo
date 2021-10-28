using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyItem1 : ItemsController
{
    private float speed1 = 40.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        MoveForward(speed1);

        if (transform.position.z > zBound)
        {
            DestroyOutOfBounds();
        }
    }
}