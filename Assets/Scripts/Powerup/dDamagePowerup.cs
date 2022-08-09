using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class dDamagePowerup : Powerup
{
    public float damageTaken;

    public override void Apply(PowerupManager target)
    {
        Pawn targetPawn = target.GetComponent<Pawn>();

        if(targetPawn != null)
        {
            damageTaken = targetPawn.damageDone;
            targetPawn.damageDone += damageTaken;
        }

    }

    public override void Remove(PowerupManager target)
    {
        Pawn targetPawn = target.GetComponent<Pawn>();

        if(targetPawn != null)
        {
            targetPawn.damageDone = damageTaken;
        }
    }
}
