using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    //
    public abstract void Start();
    public abstract void Update();
    //needs a bullet prefab, fireForce(speed?), damage number, and bullet life(how long the bullet can travel)
    public abstract void Shoot(gameObject bulletPrefab, float fireForce, float damageDone, float lifespan);
}
