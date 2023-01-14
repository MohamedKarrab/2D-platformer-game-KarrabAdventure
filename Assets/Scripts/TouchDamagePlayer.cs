using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDamagePlayer : MonoBehaviour
{
   
    public int damage = 20;
    public Rigidbody2D playerRigidbody;
    public float bumpForce = 50f;
    public float bumpForceY = 10f;
    public PlayerStats player;
  

    private void OnCollisionEnter2D(Collision2D other)
    {
       
        player = other.collider.GetComponent<PlayerStats>();
        if (player)
        {
            player.TakeDamage(damage);
            playerRigidbody = playerRigidbody.GetComponent<Rigidbody2D>();
            playerRigidbody.velocity = new Vector2(0, 0);
            playerRigidbody.AddForce(new Vector2(-bumpForce * transform.right.x ,bumpForceY ), ForceMode2D.Impulse);
        }
    }

   
}
