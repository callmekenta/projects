using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private int waypointIndex = 0;
    [SerializeField] private float closeEnoughDistance = 1f;
    [SerializeField] private bool loop = true;
    private NavMeshAgent agent;
    private Animator anim;
    private bool patrolling = true;

    private void Awake(){
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void Start(){
        if (agent != null && waypoints.Length > 0 && waypointIndex < waypoints.Length){
            agent.SetDestination(waypoints[waypointIndex].position);
        }
    }

    void Update(){
        if (!patrolling){
            return;
        }
        float distanceToWaypoint = Vector3.Distance(agent.transform.position, waypoints[waypointIndex].position);
        if (distanceToWaypoint < closeEnoughDistance){
            waypointIndex++;

            if (waypointIndex >= waypoints.Length){
                if(loop){
                    waypointIndex = 0;
                }
                else{
                    patrolling = false;
                    return;
                }
            }
        }

        agent.SetDestination(waypoints[waypointIndex].position);
    }

}
