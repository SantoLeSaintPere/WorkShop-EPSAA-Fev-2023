using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public Vector3 offest;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = target.position + offest;
    }
    private void FixedUpdate()
    {
        FollowSmooth();
    }
    void FollowSmooth()
    {
        Vector3 targetPosition = target.position;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition + offest, speed * Time.fixedDeltaTime);
        transform.position = smoothedPosition;
    }
}
