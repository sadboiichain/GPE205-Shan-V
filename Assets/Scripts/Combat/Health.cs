using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //variables for health, floats for decibels
    public float maxHealth;
    public float currentHealth;
    //a variable since damage numbers are unknown
    public float damageTaken;
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
    public void TakeDamage()
    {
        currentHealth = damageTaken;
    }

}
