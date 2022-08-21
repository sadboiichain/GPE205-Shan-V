using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public KeyPowerup powerup;
    public Spawner spawn;

    public void OnTriggerEnter(Collider other)
    {
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();

        Pawn pawn1 = other.gameObject.GetComponent<Pawn>();

        //if the other object has a power up Controller
        if(powerupManager != null)
        {
            //add the powerup
            powerupManager.Add(powerup);

            pawn1.control.AddToScore(50);
        
            //destroy this object
            Destroy(gameObject);

            GameManager.instance.powerList.Remove(gameObject);

            GameManager.instance.manager.pick.PlayPickup();

        }
    }
}
