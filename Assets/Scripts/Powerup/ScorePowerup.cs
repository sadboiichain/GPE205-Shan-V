using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScorePowerup : Powerup
{
    public float scoreToAdd;

    public override void Apply(PowerupManager target)
    {
        Pawn pawn1 = target.GetComponent<Pawn>();
        PlayerController control = pawn1.GetComponent<PlayerController>();

        if(control != null)
        {
            control.AddToScore(50);
        }
    }

    public override void Remove(PowerupManager target)
    {
    }
}
