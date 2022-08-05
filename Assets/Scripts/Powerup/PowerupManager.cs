using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public List<Powerup> powerups;
    private List<Powerup> removedPowerupQueue;

    // Start is called before the first frame update
    void Start()
    {
        powerups = new List<Powerup>();   
        removedPowerupQueue = new List<Powerup>();      
    }
    // Update is called once per frame
    void Update()
    {
        DecrementPowerupTimers(); 
    }

    private void LateUpdate()
    {
        ApplyRemovePowerupsQueue();
    }

    //add a powerup
    public void Add(Powerup toAdd)
    {
        //apply the powerup
        toAdd.Apply(this);
        //save it to the list
        powerups.Add(toAdd);
    }

    //remove a powerup
    public void Remove(Powerup toRemove)
    {
        //remove the powerup
        toRemove.Remove(this);
        //add to the queue
        removedPowerupQueue.Add(toRemove);

    }

    public void DecrementPowerupTimers()
    {
        //put each object in "powerups" into the variable "powerup", one at a time, then do the body
        foreach (Powerup power in powerups)
        {
            //subtract the time
            power.duration -= Time.deltaTime;
            //if time is up, remove powerup
            if(power.duration <= 0)
            {
                Remove(power);
            }
        }
    }

    private void ApplyRemovePowerupsQueue()
    {
        
        //remove the powerups in the temp list
        foreach(Powerup power in removedPowerupQueue)
        {
            powerups.Remove(power);
        }
        //reset the temp list
        removedPowerupQueue.Clear();
    }
}
