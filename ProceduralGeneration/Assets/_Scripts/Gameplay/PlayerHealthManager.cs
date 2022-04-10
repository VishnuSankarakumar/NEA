using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public static PlayerHealthManager playerHealthManager;

    public Slider healthbar;

    public GameObject player;
    public float health;
    public float maxHealth;
    private float heal;//all variables need to be assigned through the editor

    private void Awake()
    {
        if (playerHealthManager != null)
        {
            Destroy(playerHealthManager);
        }
        else
        {
            playerHealthManager = this;
        }
        DontDestroyOnLoad(this);
    }


    void Start() //Start() is called before the first frame
    {
        health = maxHealth; //initialises health so that it is at max
        healthbar.value = 1; //initialises health bar to be full
    }

    public void DealDamage(float damage) //damage dealth by that specific projectile is passed in
    {
        health -= damage; //damage deducted from health
        CheckDeath(); //method to check if health <= 0 is called
        healthbar.value = CalculateHealth();
        Debug.Log(health);
    }

    private float CalculateHealth()
    {
        return (health / maxHealth);
    }

    public void HealCharacter()
    {
        health += heal;
        CheckOverHeal();
    }

    private void CheckDeath()
    {
        if (health <= 0)
        {
            Destroy(player); //eliminates player
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
