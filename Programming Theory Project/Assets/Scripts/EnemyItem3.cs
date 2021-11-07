using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyItem3 : ItemsController //INHERITANCE
{
    private float speed3 = 60.0f; //ENCAPSULATION
    private float damage3 = 3; //ENCAPSULATION
    private PlayerController playerController; //ENCAPSULATION

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    public override void Update() //POLYMORPHISM
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
            playerController.SubstractHealth(damage3);
            Destroy(gameObject);
        }
    }
}
