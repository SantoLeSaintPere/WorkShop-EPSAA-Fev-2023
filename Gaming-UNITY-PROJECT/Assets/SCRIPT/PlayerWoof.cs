using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWoof : MonoBehaviour
{
    public GameObject img;
    public float woofTimer;

    public bool notDetected, woofing;
    bool canReWoof;
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
    }

    IEnumerator Woof()
    {
        img.SetActive(true);
        woofing = true;
        canReWoof=false;
        yield return new WaitForSeconds(woofTimer);
        img.SetActive(false);
        woofing=false;
        canReWoof= true;
    }
}
