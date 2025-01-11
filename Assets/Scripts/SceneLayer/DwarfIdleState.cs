using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfIdleState : StateMachineBehaviour
{
    float timer;
    public float idleTime = 4f; //how much animal is still


    Transform player; // to know if player is close to us

    public float detectionAreaRadius = 18f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) //start
    {
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Wizard").transform; // finds by tag instead of dragging in the inspector
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)//update
    {
        timer += Time.deltaTime;
        if ( timer > idleTime)
        {
            //Debug.Log("Idle Time Expired: Switching to Walk State");
            animator.SetBool("IsWalking",true);
        }

        float distanceFromPlayer = Vector3.Distance(player.position, animator.transform.position);
        if (distanceFromPlayer < detectionAreaRadius)
        {
            //Debug.Log("Distance from Player: " + distanceFromPlayer);
            animator.SetBool("IsChasing", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state

}
