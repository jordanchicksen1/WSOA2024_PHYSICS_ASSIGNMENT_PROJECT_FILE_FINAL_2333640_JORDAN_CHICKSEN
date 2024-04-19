using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doublePointsSpawner : MonoBehaviour
{
    public GameObject doublePointsObject;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    public GameObject point1; 
    public GameObject point2;
    
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed;
    public AudioSource src;
    public AudioClip sfx1;

    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
        rb = GetComponent<Rigidbody2D>();
        currentPoint = point1.transform;
    }




    public void SpawnObject()
    {
        Instantiate(doublePointsObject, transform.position, transform.rotation);
        src.clip = sfx1;
        src.Play();

        if (stopSpawning ) 
        {
            CancelInvoke("SpawnObject");
        }
    }

    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
       if (currentPoint == point1.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
       else 
        { 
         rb.velocity = new Vector2(-speed, 0);  
        }

       if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == point2.transform) 
        {
            currentPoint = point1.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == point1.transform)
        {
            currentPoint = point2.transform;
        }
    }
}
