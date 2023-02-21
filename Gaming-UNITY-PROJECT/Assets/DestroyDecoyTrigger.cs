using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyDecoyTrigger : MonoBehaviour
{
    public float timeToDestroyAfterTrigger = 3;
    public float timeToDestroyOverTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDestroyOverTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Debug.Log("DECOY FOUND");
            Destroy(gameObject, timeToDestroyAfterTrigger);
        }
    }
}
