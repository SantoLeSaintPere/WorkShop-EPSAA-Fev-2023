using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoardEffect : MonoBehaviour
{

    
     Camera theCam;

    private void Awake()
    {
        theCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
            transform.LookAt(theCam.transform);
            transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y -180, 0f);
    }
}
