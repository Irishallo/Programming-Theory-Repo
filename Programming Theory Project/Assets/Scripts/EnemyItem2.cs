using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyItem2 : ItemsController
{
    private float speed2 = 50.0f;
    private float damage2 = 4;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController.SubstractHealth(damage2);
            Destroy(gameObject);
        }
    }
}
