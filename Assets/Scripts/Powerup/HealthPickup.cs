using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public HealthPowerup powerup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //code to rotate the object
        //transform.Rotate(0f, 5 * Time.deltaTime, 0f);
    }

    //get 
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
        }
    }
}
