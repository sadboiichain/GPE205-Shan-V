using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup
{
    public float duration;
    public bool isPermanent;


    //apply the powerup
    public abstract void Apply(PowerupManager target);
    //remove the powerup
    public abstract void Remove(PowerupManager target);
}
