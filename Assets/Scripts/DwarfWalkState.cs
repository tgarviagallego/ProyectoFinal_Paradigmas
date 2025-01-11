using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEditor.Experimental.GraphView;

public class DwarfWalkState : StateMachineBehaviour
{
    float timer;
    public float walkingTime = 10f; //how much animal is still


    Transform player; // to know if player is close to us
    NavMeshAgent agent; // the ai we are going to use

    public float detectionAreaRadius = 18f;
    public float walkSpeed = 4f;

    List<Transform> waypointsList = new List<Transform>();// positions around the bear to know where to go


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // initialize
        player = GameObject.FindGameObjectWithTag("Wizard").transform;
        agent = animator.GetComponent<NavMeshAgent>();


        agent.speed = walkSpeed;
        timer = 0;

        // get waypoints and move to the first one
        GameObject waypointsCluster = animator.GetComponent<DwarfWaypoints>().monsterWaypointsCluster;
        foreach (Transform t in waypointsCluster.transform)
        {
            waypointsList.Add(t);
        }

        Vector3 firstPosition = waypointsList[Random.Range(0,waypointsList.Count)].position;
        agent.SetDestination(firstPosition);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // if arrived at one waypoint, move to other
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(waypointsList[Random.Range(0, waypointsList.Count)].position);
        }

        // idle
        timer += Time.deltaTime;
        if (timer > walkingTime) 
        {
            animator.SetBool("IsWalking", false);

        }

        // chase state 
        float distanceFromPlayer = Vector3.Distance(player.position, animator.transform.position);
        if (distanceFromPlayer < detectionAreaRadius)
        {
            animator.SetBool("IsChasing", true);
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }


}
