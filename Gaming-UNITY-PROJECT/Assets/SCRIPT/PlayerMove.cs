using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float speed = 2;
    public GameObject bidule;

    // Start is called before the first frame update
    void Start()
    {
        bidule.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            bidule.SetActive(true);
        }

        else
        {
            bidule.SetActive(false);
        }
    }
}
