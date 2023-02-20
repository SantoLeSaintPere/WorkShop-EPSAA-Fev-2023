using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FovTest : MonoBehaviour
{

    public float fovAngle = 90f;
    public Transform fovPoint;
    public float range = 8;

    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        float angle = Vector3.Angle(dir, fovPoint.up);
        RaycastHit2D r;

        if(Physics.Raycast(fovPoint.position, target.position - transform.position, out r, range)
        {
            if (r.collider.CompareTag("Player"))
            {
                print("SEEN !");
                Debug.DrawRay(fovPoint.position, dir, Color.red);

            }
            else
            {
                print("HIDE");

            }
        }
    }
}
