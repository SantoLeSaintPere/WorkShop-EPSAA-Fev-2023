using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoadLastPosition : MonoBehaviour
{
    public SaveS save;
    public Vector3 firstPos;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = save.Lastposition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
