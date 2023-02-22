using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHide : MonoBehaviour
{
    public GameObject body;
    // Start is called before the first frame update
    void Start()
    {
        body = GameObject.FindGameObjectWithTag("Body");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            body.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        body.SetActive(true);
    }
}
