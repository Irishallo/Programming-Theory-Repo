using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodItem2 : ItemsController //INHERITANCE
{
    private float healthBonus1 = 10; //ENCAPSULATION
    private PlayerController playerController; //ENCAPSULATION

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController.AddHealth(healthBonus1);
            Destroy(gameObject);
        }
    }
}
