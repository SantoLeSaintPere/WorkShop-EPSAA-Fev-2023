using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{


    GameObject player;
    int patrolInt;
    NavMeshAgent agent;
    float normalSpeed;
    bool targetAquiered;

    [Header("Set Up")]
    public Transform[] patrolPoints;
    public float speed;
    public float runSpeed;
    public float stopDistance;
    public GameObject img;

    [Header("Field Of View")]
    public float viewRadius;

    [Range(0, 360)]
    public float viewAngle;
    public LayerMask targetMask;
    public LayerMask obstacleMask;
    public List<Transform> visibleTargets = new List<Transform>();

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GetComponent<NavMeshAgent>().speed = speed;
        patrolInt = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        normalSpeed = speed;
        img.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //NormalPatrol();
        PatrolNChase();
    }


    void NormalPatrol()
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

    void PatrolNChase()
    {

        FindVisibleTargets();
        if(targetAquiered == true)
        {
            agent.SetDestination(player.transform.position);
            speed = runSpeed;
            img.SetActive(true);
        }

        else
        {
            img.SetActive(false);
            agent.SetDestination(patrolPoints[patrolInt].position);
            speed = normalSpeed;

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

    void FindVisibleTargets()
    {
        //visibleTargets.Clear();
        targetAquiered = false;
        Collider[] targetInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        for (int i = 0; i < targetInViewRadius.Length; i++)
        {
            Transform target = targetInViewRadius[i].transform;
            Vector3 dirTotarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, dirTotarget) < viewAngle / 2)
            {
                float distToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirTotarget, distToTarget, obstacleMask))
                {
                    //visibleTargets.Add(target);
                    targetAquiered = true;
                }
            }


        }
    }
    public Vector3 dirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
