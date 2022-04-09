using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float heal; //all variables need to be assigned through the editor

    
    void Start() //Start() is called before the first frame
    {
        health = maxHealth; //initialises health so that it is at max
    }

    public void DealDamage(float damage) //damage dealth by that specific projectile is passed in
    {
        health -= damage; //damage deducted from health
        CheckDeath(); //method to check if health <= 0 is called
    }

    public void HealCharacter()
    {
        health += heal;
        CheckOverHeal();
    }

    private void CheckDeath()
    {
        if(health<=0)
        {
            Destroy(gameObject); //eliminates enemy
        }
    }

    private void CheckOverHeal()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
