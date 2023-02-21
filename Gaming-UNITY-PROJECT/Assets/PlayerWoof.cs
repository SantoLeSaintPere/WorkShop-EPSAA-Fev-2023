using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWoof : MonoBehaviour
{
    public Vector3 lastPosition;
    public GameObject img;
    public float woofTimer;

    public bool canReWoof;

    public GameObject lastPosObj;
    GameObject decoy;
    // Start is called before the first frame update
    void Start()
    {
        img.SetActive(false);
        canReWoof = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && canReWoof == true)
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
        Instantiate(lastPosObj, lastPosition, Quaternion.identity);
        yield return new WaitForSeconds(woofTimer);
        img.SetActive(false);
    }
}
