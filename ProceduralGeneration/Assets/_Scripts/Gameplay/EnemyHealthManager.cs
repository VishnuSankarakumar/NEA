using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float heal; //all variables need to be assigned through the editor

    public GameObject healthbar;
    public Slider healthBarSlider;

    
    void Start() //Start() is called before the first frame
    {
        health = maxHealth; //initialises health so that it is at max
    }

    public void DealDamage(float damage) //damage dealth by that specific projectile is passed in
    {
        healthbar.SetActive(true); 
        health -= damage; //damage deducted from health
        CheckDeath(); //method to check if health <= 0 is called
        healthBarSlider.value = CalculateHealth();
        Debug.Log("Enemy Health: " + healthBarSlider.value);
    }

    private float CalculateHealth()
    {
        return (health / maxHealth); //this is the calculation required to change health into a proportion of max
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
