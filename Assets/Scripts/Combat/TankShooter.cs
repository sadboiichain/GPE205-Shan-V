using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : Shooter
{
    //bulletSpawn transform
    public Transform firepointTransform;

    // Start is called before the first frame update
    public override void Start()
    {
    }

    // Update is called once per frame
    public override void Update()
    {
    }

    public override void Shoot(GameObject bulletPrefab, float fireForce, float damageDone, float lifespan)
    {
        //instantiate the bullet prefab
        GameObject newBullet = Instantiate(bulletPrefab, firepointTransform.position, firepointTransform.rotation) as GameObject;

        //get damageOnHit component
        DamageOnHit doh = newBullet.GetComponent<DamageOnHit>();

        //if the doh script exists
        if(doh != null)
        {
            //set damageDone to this bullet...?
            doh.damageDone = damageDone;

            //set the owner to the pawn that shot this bullet
            doh.owner = GetComponent<Pawn>();
        
        }

        //get the rigidbody component
        Rigidbody rb = newBullet.GetComponent<Rigidbody>();

        //if the rigidbody exists
        if( rb != null)
        {
            //.addForce to make it move forward
            rb.AddForce(firepointTransform.forward * fireForce);
        }

        //destroy the projectile after a set time
        Destroy(newBullet, lifespan);
        
    }
}
