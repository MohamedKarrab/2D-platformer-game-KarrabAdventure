using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enraged : MonoBehaviour
{
    Enemy enemy;
    Animator animator;
    private void Start()
    {
        enemy = GetComponent<Enemy>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (enemy.health <= (enemy.maxHealth / 2))
        {
            animator.SetBool("IsEnraged", true);
        }
    }
}

