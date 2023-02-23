using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Animator anim;


    public float speed = 2;
    public float waterSpeedMultiplier = 3.5f;
    float runSpeed;
    bool  isIdle;

    public float normalSpeed;
    float turnSmoothVelocity;

    public float turnSmoothTime;

    public GameObject model;
    Rigidbody rb;

    private void Start()
    {
        normalSpeed = speed;
        runSpeed = speed * 2;
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }
    void Update()
    {

        RunSPeed();
        // Move();
        MoveA();
    }

    /*void Move()
    {
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow)  || Input.GetAxisRaw("Vertical") > 0)
        {
            transform.Translate(Vector3.forward.normalized * speed * Time.deltaTime);
            model.transform.eulerAngles = new Vector3(0,0,0);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.GetAxisRaw("Vertical") < 0)
        {
            transform.Translate(Vector3.back.normalized * speed * Time.deltaTime);

            model.transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow) || Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector3.left.normalized * speed * Time.deltaTime);

            model.transform.eulerAngles = new Vector3(0, -90, 0);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector3.right.normalized * speed * Time.deltaTime);

            model.transform.eulerAngles = new Vector3(0, 90, 0);
        }

        else
        {
            transform.Translate(Vector3.zero);
        }
    }*/

    private void MoveA()
    {

        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.Z) || Input.GetAxisRaw("Vertical") > 0)
        {
            moveZ = +1;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetAxisRaw("Vertical") < 0)
        {
            moveZ = -1;

        }

        if (Input.GetKey(KeyCode.Q) || Input.GetAxisRaw("Horizontal") < 0)
        {
            moveX = -1;

        }

        if (Input.GetKey(KeyCode.D) || Input.GetAxisRaw("Horizontal") > 0)
        {
            moveX = +1;

        }
        Vector3 direction = new Vector3(moveX, 0, moveZ).normalized;

         isIdle = moveX == 0 && moveZ == 0;
        if (isIdle)
        {
            rb.velocity = Vector3.zero;
            { 
                anim.SetBool("walking", false);
            }
        }

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

           Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                anim.SetBool("walking", true);
            rb.velocity = moveDir.normalized * speed;
        }
    }

    void RunSPeed()
    {
        if (Input.GetKey(KeyCode.Space) && isIdle == false || Input.GetAxisRaw("RT") > 0 && isIdle == false)
        {

            anim.SetBool("running", true);

            if (GetComponent<PlayerWaterSystem>().water > 0 && GetComponent<PlayerWaterSystem>().piss != GetComponent<PlayerWaterSystem>().maxPiss)
            {
                speed = runSpeed * waterSpeedMultiplier;
            }

            else
            {

                speed = runSpeed;
            }
        }

        else
        {
            anim.SetBool("running", false);
            speed = normalSpeed;

            if (GetComponent<PlayerWaterSystem>().water > 0 && GetComponent<PlayerWaterSystem>().piss != GetComponent<PlayerWaterSystem>().maxPiss)
            {
                speed = normalSpeed * waterSpeedMultiplier;
            }

            else
            {

                speed = normalSpeed;
            }
        }
    }
}
