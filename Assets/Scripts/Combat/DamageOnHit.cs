using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    //variable for damage
    public float damageDone;
    //Pawn that fired the shot
    public Pawn owner;

    //called by rigidbody to deal damage
    public void OnTriggerEnter(Collider other)
    {
        //get the health component from the object collided with
        Health otherHealth = other.GetComponent<Health>();

        //deals damage if health component exists
        if(otherHealth != null)
        {
            //deal damage if health is found
            otherHealth.TakeDamage(owner, damageDone);

            GameManager.instance.manager.hit.PlayHit();
        }

        //destroy this object, regardless of success
        Destroy(gameObject); 
    }
}
