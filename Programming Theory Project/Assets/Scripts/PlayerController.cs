using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private SpawnManager spawnManager; //ENCAPSULATION
    private float horizontalInput; //ENCAPSULATION
    private float verticalInput; //ENCAPSULATION
    private float xRange = 110.0f; //ENCAPSULATION
    private float zRange = 35.0f; //ENCAPSULATION
    private int m_Score = 0; //ENCAPSULATION
    private float maxHealth = 20; //ENCAPSULATION
    private float m_Health = 20; //ENCAPSULATION
    public float health //ENCAPSULATION
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

    public int score //ENCAPSULATION
    {
        get { return m_Score; }
        set
        {
            if (value < 0)
            {
                m_Score = 0;
            }
            else
            {
                m_Score = value;
            }
        }
    }

    public bool powerActive = false;
    [SerializeField] float speed; //ENCAPSULATION
    [SerializeField] Image healthBarImage; //ENCAPSULATION
    [SerializeField] GameObject powerupIndicator; //ENCAPSULATION
    [SerializeField]  TextMeshProUGUI scoreText; //ENCAPSULATION

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        powerupIndicator.transform.position = transform.position;
        scoreText.text = "Score: " + score;
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

    private void MovePlayer() //ABSTRACTION
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

    private void HealthUpdate() //ABSTRACTION
    {
        healthBarImage.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1f);
    }

    public void SubstractHealth(float healthSubstracter) //ABSTRACTION
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

    public void AddHealth(float healthAdder) //ABSTRACTION
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

    public void ScoreUpdate() //ABSTRACTION
    {
        if (powerActive)
        {
            score += 2;
            Debug.Log("add 2");
        }
        else
        {
            score += 1;
            Debug.Log("add 1");
        }

        scoreText.text = "Score: " + score;
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
