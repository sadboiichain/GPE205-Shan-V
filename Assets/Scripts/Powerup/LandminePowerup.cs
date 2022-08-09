using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LandminePowerup : Powerup
{
    public float damageTaken;

    public override void Apply(PowerupManager target)
    {
        Health targetHealth = target.GetComponent<Health>();

        if(targetHealth != null)
        {
            targetHealth.TakeDamage(target.GetComponent<Pawn>(), damageTaken);
        }

    }

    public override void Remove(PowerupManager target)
    {
    }

}
