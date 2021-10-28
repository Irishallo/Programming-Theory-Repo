using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyItem3 : ItemsController
{
    private float speed3 = 60.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        MoveForward(speed3);

        if (transform.position.z > zBound)
        {
            DestroyOutOfBounds();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
