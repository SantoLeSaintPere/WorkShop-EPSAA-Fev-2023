using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 2;
    public float runSpeed;

    public float waterSpeed;
    public float waterRunSPeed;

    float normalSpeed;

    private void Start()
    {
        normalSpeed = speed;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }

        else
        {
            speed = normalSpeed;
        }

        Move();
        
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(Vector3.forward.normalized * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back.normalized * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.left.normalized * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right.normalized * speed * Time.deltaTime);
        }

        else
        {
            transform.Translate(Vector3.zero);
        }
    }
}
