using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float xPos = 115.0f;
    public float xBounds = 130.0f;
    //public float speed = 10;
    public bool movingLeft = false;
    public bool movingRight = false;
    public bool shootingOk = false;

    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public virtual void MoveEnemyRight(float speed)
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);        
    }

    public virtual void MoveEnemyLeft(float speed)
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    public virtual void RemoveEnemy()
    {
        movingLeft = false;
        movingRight = false;
        Destroy(gameObject);
    }

    public virtual void ShootItem(GameObject item, float shootSpeed)
    {
        if (shootingOk)
        {
            shootingOk = false;
            Instantiate(item, transform.position, item.transform.rotation);
            Invoke("ShootTimer", shootSpeed);
        }
    }

    public virtual void ShootTimer()
    {
        shootingOk = true;
    }
}
