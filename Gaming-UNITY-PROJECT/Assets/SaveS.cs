using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu()]
public class SaveS : ScriptableObject
{
    public Vector3 Lastposition;
    public Vector3 firstPos;
    // 0 false 1 true
    public int isLoad;
   
}
