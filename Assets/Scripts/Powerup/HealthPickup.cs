using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public HealthPowerup powerup;
    public Spawner spawn;

    public void OnTriggerEnter(Collider other)
    {
        //variable to store the other objects powerup controller
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();

        //if the other object has a power up Controller
        if(powerupManager != null)
        {
            //add the powerup
            powerupManager.Add(powerup);
        
            //destroy this object
            Destroy(gameObject);

            GameManager.instance.powerList.Remove(gameObject);
           

        }
    }
}
