using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float xRange = 110.0f;
    private float zRange = 35.0f;
    private int m_Health = 20;
    public int health
    {
        get { return m_Health; }
        set { if (value < 0)
                {
                    m_Health = 0;
                    Debug.Log("value below 0");
                } else if (value > 20)
                {
                    m_Health = 20;
                    Debug.Log("value above 20");
                } else
                {
                    m_Health = value;
                    Debug.Log("value correct!");
                }
             }
    }
    [SerializeField] float speed;
    [SerializeField] TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        HealthUpdate();
    }

    private void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        // Check for left and right bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // Check for top and bottom bounds
        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x , transform.position.y, -zRange);
        }

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
    }

    private void HealthUpdate()
    {
        healthText.text = "Health: " + health;
    }

    public void SubstractHealth(int healthSubstracter)
    {
        health -= healthSubstracter;
    }

    public void AddHealth(int healthAdder)
    {
        health += healthAdder;
    }
}
