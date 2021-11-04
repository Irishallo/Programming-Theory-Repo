using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float xRange = 110.0f;
    private float zRange = 35.0f;
    private float maxHealth = 20;
    private float m_Health = 20;
    private SpawnManager spawnManager;
    public float health
    {
        get { return m_Health; }
        set { if (value < 0)
                {
                    m_Health = 0;
                } else if (value > 20)
                {
                    m_Health = 20;
                } else
                {
                    m_Health = value;
                }
             }
    }
    [SerializeField] float speed;
    [SerializeField] Image healthBarImage;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
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
        healthBarImage.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1f);
    }

    public void SubstractHealth(float healthSubstracter)
    {
        health -= healthSubstracter;
        HealthUpdate();
        if(health < 1)
        {
            spawnManager.GameOver();
        }
    }

    public void AddHealth(float healthAdder)
    {
        health += healthAdder;
        HealthUpdate();
    }
}
