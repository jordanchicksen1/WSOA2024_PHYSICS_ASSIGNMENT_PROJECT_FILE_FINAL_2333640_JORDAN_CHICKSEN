using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporterSpawner : MonoBehaviour
{
    public GameObject teleporter1;
    public bool stopSpawning = false;
    public float spawnTime; 
    public float spawnDelay;

    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);

    }

    public void SpawnObject()
    {
     Instantiate(teleporter1, transform.position, transform.rotation);
    
        if(stopSpawning) 
        {
            CancelInvoke("SpawnObject");
        }


    }






}
