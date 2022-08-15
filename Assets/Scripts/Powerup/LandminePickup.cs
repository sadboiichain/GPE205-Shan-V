using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandminePickup : MonoBehaviour
{
    public LandminePowerup landmine;
    public Spawner spawn;

    public void OnTriggerEnter(Collider other)
    {
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();

        if(powerupManager != null)
        {
            powerupManager.Add(landmine);
            GameManager.instance.powerList.Remove(gameObject);
            Destroy(gameObject);
            
        }

    }
}
