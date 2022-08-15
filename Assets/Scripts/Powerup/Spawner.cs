using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pickupPrefab;
    public float spawnDelay;
    public float nextSpawnTime;
    private Transform tf;
    public GameObject spawnedPickup;

    // public bool canSpawn;

    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = Time.time + spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.powerList.Count < GameManager.instance.pickupLimit)
        {   
            // if() 
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

                        

                    GameManager.instance.powerList.Add(spawnedPickup);
                }
            }
            else
            {
                
                //otherwise reset the countdown to delay the spawn
                nextSpawnTime = Time.time + spawnDelay;
            }    
        }

    }
}
