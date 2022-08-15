using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dDamagePickup : MonoBehaviour
{
    public dDamagePowerup damage;

    public Spawner spawn;

    public void OnTriggerEnter(Collider other)
    {
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();

        if(powerupManager != null)
        {
            powerupManager.Add(damage);

            Destroy(gameObject);

            GameManager.instance.powerList.Remove(gameObject);


            
        }

    }
}
