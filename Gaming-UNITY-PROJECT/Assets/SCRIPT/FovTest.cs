using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FovTest : MonoBehaviour
{
    public float viewRadius;

    [Range(0,360)]
    public float viewAngle;


    public LayerMask targetMask, obstacleMask;


    public List<Transform> visibleTargets = new List<Transform>();


    private void Update()
    {
        FindVisibleTargets();
    }
    void FindVisibleTargets()
    {
        visibleTargets.Clear();
        Collider[] targetInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        for(int i =0; i < targetInViewRadius.Length; i++)
        {
            Transform target = targetInViewRadius[i].transform;
            Vector3 dirTotarget = (target.position - transform.position).normalized;

            if(Vector3.Angle(transform.forward, dirTotarget) < viewAngle /2)
            {
                float distToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirTotarget, distToTarget, obstacleMask))
                {
                    visibleTargets.Add(target);
                }
            }

            
        }
    }
    public Vector3 dirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if(!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

}
