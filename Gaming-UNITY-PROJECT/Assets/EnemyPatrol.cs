using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    NavMeshAgent agent;
    public float speed;
    public float stopDistance;

    int patrolInt;

    public float detectionRange;

    GameObject player;
    public LayerMask playerLayer;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GetComponent<NavMeshAgent>().speed = speed;
        patrolInt = 0;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] playerDetect = Physics.OverlapSphere(transform.position, detectionRange, playerLayer);
        if(playerDetect.Length > 0)
        {
            speed = speed * 2;
            GetComponent<NavMeshAgent>().stoppingDistance = stopDistance;
            agent.SetDestination(player.transform.position);
        }

        else
        {
            agent.SetDestination(patrolPoints[patrolInt].position);

            if (transform.position.x == patrolPoints[patrolInt].position.x
                && transform.position.z == patrolPoints[patrolInt].position.z)
            {
                patrolInt++;
            }

            if (patrolInt == patrolPoints.Length)
            {
                patrolInt = 0;
            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
