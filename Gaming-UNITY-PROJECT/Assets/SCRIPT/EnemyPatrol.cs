using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{

    Animator anim;
    GameObject player;
    int patrolInt;
    NavMeshAgent agent;
    float normalSpeed;
    bool targetAquiered;

    [Header("Set Up")]
    public Transform[] patrolPoints;
    public float speed;
    public float runSpeed;
    public float rotationSpeed = 0.025f;
    public float stopDistance;
    public GameObject img;

    [Header("Field Of View")]
    public float viewRadius;

    [Range(0, 360)]
    public float viewAngle;
    public LayerMask targetMask;
    public LayerMask obstacleMask;
    public List<Transform> visibleTargets = new List<Transform>();

    [Header("Woof")]
    public float woofDetectionRange;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
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
        Collider[] playerWoof = Physics.OverlapSphere(transform.position, woofDetectionRange, targetMask);
        if(playerWoof.Length > 0 && player.GetComponent<PlayerWoof>().woofing)
        {
            anim.SetTrigger("alert");
        }

        else
        {
            PatrolNChase();
        }
    }

    public void stopMove()
    {
        agent.isStopped = true;
    }

    public void goMove()
    {
        anim.ResetTrigger("alert");
        agent.isStopped = false;
    }

    void PatrolNChase()
    {

        FindVisibleTargets();
        if(targetAquiered == true)
        {

            player.GetComponent<PlayerWoof>().notDetected = false;
            anim.SetBool("running", true);
            LookAtPlayer();
            agent.SetDestination(player.transform.position);
            speed = runSpeed;
            img.SetActive(true);
        }

        else
        {

            player.GetComponent<PlayerWoof>().notDetected = true;
            anim.SetBool("running", false);
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


    void LookAtPlayer()
    {
        Quaternion target = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, rotationSpeed);
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


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, woofDetectionRange);
    }
}
