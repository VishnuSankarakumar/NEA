using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectiles : MonoBehaviour
{
    public GameObject projectile; //the bullet itself
    public GameObject player; //the player's transform component which the player's position can be retrieved
    public float minDamage;
    public float maxDamage; //damage dealth will always be a random number between the lower and upper bounds of these two numbers
    public float projectileForce; //force provided to each bullet before being fired
    public float cooldown; //cooldown interval between each time enemy shoots projectile

    private void Start()
    {
        StartCoroutine(ShootPlayer());
        player = FindObjectOfType<Player>().gameObject;
    }

    IEnumerator ShootPlayer()
    {
        yield return new WaitForSeconds(cooldown); //yield return pauses script, and WaitForSeconds(cooldown) tells Unity how long to pause for
        if (player != null) //checks that player still exists
        {
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity); //instantiates projectile
            Vector2 myPos = transform.position; //gets coordinates of enemy
            Vector2 targetPos = player.transform.position; //gets coordinates of player
            Vector2 direction = (targetPos - myPos).normalized; //calculates vector to get from enemy to player
            bullet.GetComponent<Rigidbody2D>().velocity = direction * projectileForce; //provides force to bullet in the calculated vector
            bullet.GetComponent<DamageByEnemy>().damage = Random.Range(minDamage, maxDamage); //determines the damage dealt randomly between min and max damage values
            StartCoroutine(ShootPlayer()); //calls the function again
        }
    }
}
