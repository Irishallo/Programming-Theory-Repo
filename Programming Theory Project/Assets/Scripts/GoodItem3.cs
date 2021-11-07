using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodItem3 : ItemsController //INHERITANCE
{
    private float healthBonus2 = 7; //ENCAPSULATION
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController.AddHealth(healthBonus2);
            Destroy(gameObject);
        }
    }
}
