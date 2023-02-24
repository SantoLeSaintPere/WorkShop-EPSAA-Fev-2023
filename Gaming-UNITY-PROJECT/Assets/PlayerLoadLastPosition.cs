using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoadLastPosition : MonoBehaviour
{
    public SaveS save;
    // Start is called before the first frame update
    void Start()
    {
        if(save.isLoad == 1)
        {
            transform.position = save.Lastposition;
        }

        else
        {
            save.firstPos = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
