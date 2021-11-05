using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyItem1 : ItemsController
{
    private float speed1 = 40.0f;
    private float damage1 = 6;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerController.SubstractHealth(damage1);
            Destroy(gameObject);
        }
    }
}
