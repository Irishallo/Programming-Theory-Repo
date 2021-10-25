using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //private float xPos = 115.0f;
    private float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemyLeft();
    }

    private void MoveEnemyRight()
    {
        if (transform.position.x > 120)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        
    }

    private void MoveEnemyLeft()
    {
        if (transform.position.x < -120)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }
}
