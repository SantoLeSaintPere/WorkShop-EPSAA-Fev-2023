using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum castState
{
    needAll, needCastShadow, needRecieveShadow
}
public class ReceiveCastShadow : MonoBehaviour
{
    public castState currenCastState;
    public Material spriteMat;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.AddComponent<MeshRenderer>().material = spriteMat;
        gameObject.GetComponent<SpriteRenderer>().material = spriteMat;
        switch (currenCastState)
        {
            case castState.needAll:
                GetComponent<SpriteRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                GetComponent<SpriteRenderer>().receiveShadows = true;
                break;


            case castState.needCastShadow:
                GetComponent<SpriteRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                break;

            case castState.needRecieveShadow:
                GetComponent<SpriteRenderer>().receiveShadows = true;
                break;
        }


    }

}
