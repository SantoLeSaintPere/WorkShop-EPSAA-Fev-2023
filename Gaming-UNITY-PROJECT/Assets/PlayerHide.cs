using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHide : MonoBehaviour
{
    LayerMask original;
    // Start is called before the first frame update
    void Start()
    {
        original = GetComponent<LayerMask>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Walls"))
        {

        }
    }
}
