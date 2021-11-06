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

    public bool powerActive = false;
    [SerializeField] float speed;
    [SerializeField] Image healthBarImage;
    [SerializeField] GameObject powerupIndicator;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        powerupIndicator.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        if(powerActive)
        {
            powerupIndicator.transform.Rotate(0, 5f, 0);
        }
    }

    private void MovePlayer()
    {
        if(spawnManager.gameActive)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            if(powerActive)
            {
                transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed * 1.5f);
                transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed * 1.5f);
            } else
            {
                transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
                transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
            }

            
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
                transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
            }

            if (transform.position.z > zRange)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
            }

            powerupIndicator.transform.position = transform.position;
        }
    }

    private void HealthUpdate()
    {
        healthBarImage.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1f);
    }

    public void SubstractHealth(float healthSubstracter)
    {
        if(powerActive)
        {
            health -= (healthSubstracter / 2);
        } else
        {
            health -= healthSubstracter;
        }
        
        HealthUpdate();
        if(health < 1)
        {
            spawnManager.GameOver();
        }
    }

    public void AddHealth(float healthAdder)
    {
        if(powerActive)
        {
            health += healthAdder * 2;
        } else
        {
            health += healthAdder;
        }
        HealthUpdate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            powerActive = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountDownRoutine());
        }
    }

    IEnumerator PowerupCountDownRoutine()
    {
        yield return new WaitForSeconds(5);
        powerActive = false;
        powerupIndicator.gameObject.SetActive(false);
    }
}
