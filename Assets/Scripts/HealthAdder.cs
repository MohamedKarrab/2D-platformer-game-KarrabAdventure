using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HealthAdder : MonoBehaviour
{
    GameObject player;
    PlayerStats playerStats;
    public int healthGain = 20;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerStats.GainHealth(healthGain);
            Destroy(gameObject);
        }
    }
}
