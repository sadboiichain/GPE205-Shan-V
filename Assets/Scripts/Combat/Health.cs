using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //variables for health
    public float maxHealth;
    public float currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //object is injured and health is lost
    public void TakeDamage(Pawn source, float damageTaken)
    {
        //add for a "log" of the damage given
        Debug.Log(source.name + " injured "+ gameObject.name);

        //remove damage value from health
        currentHealth -= damageTaken;

        //clamps to reduce chances of excessive value loss
        currentHealth = Math.Clamp(currentHealth, 0, maxHealth);
        
        //check if the player dies
        if (currentHealth <= 0)
        {   Debug.Log(gameObject.name + " died.");
            PlayerController control = source.GetComponent<PlayerController>();
            if(control != null)
            {   Debug.Log("controller found");
                control.AddToScore(100);
            }
            Die();
        }
    
    }

    //mentioned in the notes, but not graded. useful if reusing code
    public void HealDamage(float heal, Pawn source)
    {
        //add heal to current health value
        currentHealth += heal;

        //clamp to limit number
        currentHealth = Math.Clamp(currentHealth, 0, maxHealth);

    }

    public void Die()
    {
        
        Destroy(gameObject);
    }

}
