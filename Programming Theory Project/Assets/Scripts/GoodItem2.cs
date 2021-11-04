using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodItem2 : ItemsController
{
    private float healthBonus1 = 10;
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
            playerController.AddHealth(healthBonus1);
            Destroy(gameObject);
        }
    }
}
