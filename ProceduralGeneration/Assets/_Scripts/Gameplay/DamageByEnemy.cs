using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageByEnemy : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Enemy")
        {
            Destroy(gameObject);
            Debug.Log("Player Hit!");
        }
    }
}
