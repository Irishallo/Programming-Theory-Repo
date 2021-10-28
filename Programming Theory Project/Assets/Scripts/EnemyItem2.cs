using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyItem2 : ItemsController
{
    private float speed2 = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        MoveForward(speed2);

        if (transform.position.z > zBound)
        {
            DestroyOutOfBounds();
        }
    }
}