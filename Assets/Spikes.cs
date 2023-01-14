using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{   public GameObject player;
    public  int damage;
    public float bumpForce;
    PlayerStats playerStats;
    Rigidbody2D playerRigidbody2D;
    void Start()
    {
        playerStats = player.GetComponent<PlayerStats>();
        playerRigidbody2D = player.GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerStats.TakeDamage(damage);
            if (player)
            {
                playerRigidbody2D.AddForce(new Vector2(0, bumpForce), ForceMode2D.Impulse);
            }
        }
    }
}
