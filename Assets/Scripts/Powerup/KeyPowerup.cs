using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KeyPowerup : Powerup
{
    public bool isKey1;
    public bool isKey2;
    public bool isKey3;

    public override void Apply(PowerupManager target)
    {
        if(isKey1){

        }
        else if(isKey2)
        {

        }
        else
        {
            GameManager.instance.CollectKey3();
        }
    }   

    public override void Remove(PowerupManager target)
    {
    }
}
