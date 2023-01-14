using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRun : StateMachineBehaviour
{   Transform player;
    Rigidbody2D rb;
    public float speed =2.5f;
    Transform transform;
    bool isFacingRight;
    LookAtPlayer lookAtPlayer;
    public float attackRange = 3f;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        transform = animator.GetComponent<Transform>();
       lookAtPlayer = animator.GetComponent<LookAtPlayer>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player)
        {
            Vector2 target = new Vector2(player.position.x, rb.position.y);
            Vector2 newPosition = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPosition);
            lookAtPlayer.LookAtPlayerFunc();
            if (Vector2.Distance(player.position, rb.position) <= attackRange)
            {
                animator.SetBool("Attack", true);
            }
            else if (Vector2.Distance(player.position, rb.position) > attackRange)
            {
                animator.SetBool("Attack", false);
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }

}
