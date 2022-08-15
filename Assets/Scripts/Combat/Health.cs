using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //variables for health
    public float maxHealth;
    public float currentHealth;

    public UIHealth UIhealth;

    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }


    //object is injured and health is lost
    public void TakeDamage(Pawn source, float damageTaken)
    {
        //add for a "log" of the damage given
        Debug.Log(source.name + " injured "+ gameObject.name);
        Pawn pawn1 = gameObject.GetComponent<Pawn>();


        //remove damage value from health
        currentHealth -= damageTaken;

        //clamps to reduce chances of excessive value loss
        currentHealth = Math.Clamp(currentHealth, 0, maxHealth);
        
        //check if the player dies
        if (currentHealth <= 0)
        {   
            source.control.AddToScore(100);
            if(pawn1.lives > 0)
            {
                GameManager.instance.RespawnPlayer(pawn1);
            }
            else
            {
                Die();
            }
            
        }

        UIhealth.UpdateHealth(currentHealth,maxHealth);    
    }

    //mentioned in the notes, but not graded. useful if reusing code
    public void HealDamage(float heal, Pawn source)
    {
        //add heal to current health value
        currentHealth += heal;

        //clamp to limit number
        currentHealth = Math.Clamp(currentHealth, 0, maxHealth);

        UIhealth.UpdateHealth(currentHealth,maxHealth);
    }

    public void Die()
    {
        Destroy(gameObject.GetComponent<Pawn>().control);
        Destroy(gameObject);
    }

}
