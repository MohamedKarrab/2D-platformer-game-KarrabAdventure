using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public int maxHealth = 50;
    public int health = 50;
    public GameObject deathEffect;
    public bool invincible = false;
    Animator animator;
    ItemSpawner itemSpawner;

    private void Start()
    {
        itemSpawner = GetComponent<ItemSpawner>();
    }
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
            itemSpawner.SpawnStuff();
            Destroy(gameObject);
        }
    }
}
