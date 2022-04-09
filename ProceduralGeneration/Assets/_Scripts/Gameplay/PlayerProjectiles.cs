using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectiles : MonoBehaviour
{
    public GameObject projectile;
    public float minDamage;
    public float maxDamage;
    public float projectileForce; //these are the attributes that will be passed in from the Unity editor that will give the code itself the required parameters

    private void Update() //called on every frame
    {
        if (Input.GetMouseButtonDown(1)) //if the mouse button is pressed
        {
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity); //bullet prefab is instantiated
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //gets current coordinates of cursor
            Vector2 myPos = transform.position; //gets coordinates of player
            Vector2 direction = (mousePos - myPos).normalized; //vector calculates to get to cursor coordinates from player
            bullet.GetComponent<Rigidbody2D>().velocity = direction * projectileForce; //sets the velocity of the rigidbody component of the bullet instantiation
            bullet.GetComponent<DamageByPlayer>().damage = Random.Range(minDamage, maxDamage); //sets damage value to be a random vallue between the lower and upper bounds
        }
    }
}
