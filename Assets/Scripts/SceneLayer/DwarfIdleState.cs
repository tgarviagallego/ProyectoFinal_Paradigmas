using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfIdleState : StateMachineBehaviour
{
    float timer;
    public float idleTime = 4f; //how much animal is still


    Transform player; // to know if player is close to us

    public float detectionAreaRadius = 18f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) //start
    {
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Wizard").transform; // finds by tag instead of dragging in the inspector
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) //update
    {
        timer += Time.deltaTime;
        if ( timer > idleTime)
        {
            animator.SetBool("IsWalking",true);
        }

        float distanceFromPlayer = Vector3.Distance(player.position, animator.transform.position);
        if (distanceFromPlayer < detectionAreaRadius)
        {
            animator.SetBool("IsChasing", true);
        }
    }

}
