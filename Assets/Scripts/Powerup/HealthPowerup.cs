using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HealthPowerup : Powerup
{
    public float healthToAdd;

    public override void Apply(PowerupManager target)
    {
        //apply health changes
        Health targetHealth = target.GetComponent<Health>();

        if(targetHealth != null)
        {
            targetHealth.HealDamage(healthToAdd, target.GetComponent<Pawn>());
        }
    }

    public override void Remove(PowerupManager target)
    {
    }

}
