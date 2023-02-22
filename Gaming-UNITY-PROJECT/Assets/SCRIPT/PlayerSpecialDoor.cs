using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpecialDoor : MonoBehaviour
{
    public bool specialDoor;
    public Collider original, sneakyColli;
    // Start is called before the first frame update
    void Start()
    {
        original.enabled = true;
        sneakyColli.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift) &&  specialDoor == true || Input.GetAxisRaw("LT") > 0 && specialDoor == true)
        {

            original.enabled = false;
            sneakyColli.enabled = true;
        }

        else
        {

            original.enabled = true;
            sneakyColli.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Door"))
        {
            specialDoor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            specialDoor = false;
        }
    }
}
