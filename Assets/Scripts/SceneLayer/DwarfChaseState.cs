using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DwarfChaseState : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;

    public float chaseSpeed = 14f;
    public float stopChasingDistance = 21f; // a bit bigger than the detection area to keep detecting
    public float attackingDistance = 1f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Wizard").transform;
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = chaseSpeed;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(player.position);
        animator.transform.LookAt(player);

        float distanceFromPlayer = Vector3.Distance(player.position, animator.transform.position);

        // check if has to stop
        if (distanceFromPlayer > stopChasingDistance)
        {
            animator.SetBool("IsChasing", false);
        }

        //check if the agent should attack
        if (distanceFromPlayer < attackingDistance)
        {
            animator.SetBool("IsAttacking", true);
        }

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }
}
