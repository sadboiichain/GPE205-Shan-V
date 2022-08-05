using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pickupPrefab;
    public float spawnDelay;
    private float nextSpawnTime;
    private Transform tf;
    private GameObject spawnedPickup;

    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = Time.time + spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        //if the object is not spawned
        if(spawnedPickup == null)
        {
            //if the time has passed to spawn a pickup
            if(Time.time > nextSpawnTime)
            {
                //spawn the item
                spawnedPickup = Instantiate(pickupPrefab, transform.position, Quaternion.identity) as GameObject;
                //set next spawn time
                nextSpawnTime = Time.time + spawnDelay;
            }
        }
        else
        {
            //otherwise reset the countdown to delay the spawn
            nextSpawnTime = Time.time + spawnDelay;
        }

    }
}
