using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int health = 100;
    public GameObject deathEffect;
    public bool invincible = false;
    public void TakeDamage(int damage)
    {
        if (!invincible)
        {
            health -= damage;

            if (health <= 0)
            {
                Die();
            }
        }
        void Die()
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
