using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;

    public float speed = 15.0f;
    public float slowedSpeed = 7.5f;
    private float xRange = 15;
    private float yHighBound = 7;
    private float yLowBound = 3;
    private float zBound = -30;

    public int pointValue;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (transform.position.z < zBound)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive && !CompareTag("PowerUp"))
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
        }
        else if(gameManager.isGameActive && CompareTag("PowerUp"))
        {
            Time.timeScale = 0.5f;
            Destroy(gameObject);
            gameManager.StartTimer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (gameObject.CompareTag("Good"))
        {
            gameManager.GameOver();
        }
    }


    Vector3 RandomSpawnPos()
    {
        float spawnPositionX = Random.Range(-xRange, xRange);
        float spawnPositionY = Random.Range(yLowBound, yHighBound);

        Vector3 randomPosition = new Vector3(spawnPositionX, spawnPositionY, 23);

        return randomPosition;
    }
}
