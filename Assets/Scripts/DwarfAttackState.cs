using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DwarfAttackState : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;

    public float stopAttackingDistance = 2.5f;
    public float attackRate = 1f; //attack rate is one second
    private float attackTimer;
    public int damageToInflict = 5; //hitpoints per second

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Wizard").transform;
        agent = animator.GetComponent<NavMeshAgent>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        LookAtPlayer(); //diff to built in LookAt, because it is attacking 

        if (attackTimer <= 0)
        {
            Attack();
            attackTimer = 1f / attackRate;
        }
        else
        { 
            attackTimer -= Time.deltaTime;
        }


        // chack if agent hast to stop the attack
        float distanceFromPlayer = Vector3.Distance(player.position, animator.transform.position);
        if (distanceFromPlayer < stopAttackingDistance)
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    private void LookAtPlayer()
    {
        Vector3 direction = player.position - agent.transform.position;
        agent.transform.rotation = Quaternion.LookRotation(direction);

        var yRotation = agent.transform.eulerAngles.y;
        agent.transform.rotation = Quaternion.Euler(0, yRotation, 0); // if for example thep kayer is higher not to rotate
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state

    private void Attack()  // if we have multiple players we have to handle who is attacked
    {
        //PlayerState.Instance.TakeDamage(damageToInflict);
    }
}
