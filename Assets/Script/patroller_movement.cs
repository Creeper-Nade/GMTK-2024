using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Jobs;

public class patroller_movement : MonoBehaviour
{
    public mob_spawn_handler mob_Spawn;
    public Transform[] patrolPoints;
    public int targetpoint;
    public NavMeshAgent agent;

    public GameObject player;
    void Start()
    {
        targetpoint=0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,patrolPoints[targetpoint].position)<=1f)
        {
            nextpoint();
        }
        Vector3 point_position= patrolPoints[targetpoint].position;
        agent.SetDestination(point_position);
    }

    void nextpoint()
    {
        targetpoint++;
        if(targetpoint >=patrolPoints.Length)
        {
            targetpoint=0;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject==player)
        {
            Debug.Log("touch");
            mob_Spawn.spawn_requested();
        }
    }
}
