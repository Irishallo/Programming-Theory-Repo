using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsController : MonoBehaviour
{
    private float m_zBound = 60.0f;
    public float zBound { get { return m_zBound; }}
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public virtual void MoveForward(float speed)
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public virtual void DestroyOutOfBounds()
    {
        Destroy(gameObject);
    }

    
}
