using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageByPlayer : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision) //method called when there is a collision
    {
        if (collision.name != "Player") //if block only executed if collision is not with the player itself
        {
            if (collision.GetComponent<EnemyHealthManager>() != null) //checks that the object collided with has the HealthManager component
            {
                collision.GetComponent<EnemyHealthManager>().DealDamage(damage); //damage dealt
            }
            
            Destroy(gameObject); //projectile destroyed
        }
    }
}
