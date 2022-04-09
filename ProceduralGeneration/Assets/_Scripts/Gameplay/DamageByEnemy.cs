using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageByEnemy : MonoBehaviour
{
    public float damage; //damage dealt by current enemy bullet passed in through editor

    void OnTriggerEnter2D(Collider2D collision) //called when there is a collision 
    {
        if (collision.tag != "Enemy") //checks that the collision is not between the enemy bullet and another enemy
        {
            if (collision.tag == "Player") //checks that the collision is between the enemy bullet and the player
            {
                PlayerHealthManager.playerHealthManager.DealDamage(damage); //deals damage
            }
            Destroy(gameObject); //bullet disappears after collision as long as it is not with another enemy
            Debug.Log("Player Hit!"); 
        }
    }
}
