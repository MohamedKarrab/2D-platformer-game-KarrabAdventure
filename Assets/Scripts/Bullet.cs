using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private LayerMask isHitable;
    public float bulletSpeed = 20f;
    public int damage = 40;
    public Rigidbody2D rigidbodyBullet;
    void Start()
    {
        rigidbodyBullet.velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        // Checks if the collider's layer is within the isHitable LayerMask
        if (((isHitable.value & (1 << collision.gameObject.layer)) > 0)) 
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            Chest chest = collision.GetComponent<Chest>();
            if (enemy)
            {
                enemy.TakeDamage(damage);
            }
            if (chest)
            {
                chest.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }

}
