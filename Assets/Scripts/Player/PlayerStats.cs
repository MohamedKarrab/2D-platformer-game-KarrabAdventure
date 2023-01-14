using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int health = 100;
    public GameObject deathEffect;
    public HealthBar healthBar;
    public int score = 0;
    public GameManager gameManager;
    public int Score
    {
        get { return score; }
    }



    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
      
    }
    private void Update()
    {
        healthBar.SetHealth(health);
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
        if (health <= 0)
        {
            Die();
        }



        void Die()
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            gameManager.Replay();
            Destroy(gameObject);
        }

    }



    public void addScore(int score)
    {
        this.score += score;
    }

    public void GainHealth(int healthGain)
    {
        health += healthGain;
        health = Mathf.Clamp(health, 0, maxHealth);
    }
}