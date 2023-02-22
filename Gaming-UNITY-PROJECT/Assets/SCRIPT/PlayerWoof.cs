using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWoof : MonoBehaviour
{
    public Vector3 lastPosition;
    public GameObject img;
    public float woofTimer;

    public bool canReWoof, notDetected;

    public GameObject lastPosObj;
    GameObject decoy;
    // Start is called before the first frame update
    void Start()
    {
        img.SetActive(false);
        canReWoof = true;
        notDetected = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) && canReWoof == true && notDetected == true || Input.GetButton("A") && canReWoof == true && notDetected == true)
        {
            StartCoroutine(Woof());
        }

        decoy = GameObject.FindGameObjectWithTag("Decoy");
        if (decoy !=null)
        {
            canReWoof=false;
        }

        else
        {
            canReWoof = true;
        }
    }

    IEnumerator Woof()
    {
        img.SetActive(true);
        lastPosition = transform.position;
        Instantiate(lastPosObj, lastPosition, lastPosObj.transform.rotation);
        yield return new WaitForSeconds(woofTimer);
        img.SetActive(false);
    }
}
