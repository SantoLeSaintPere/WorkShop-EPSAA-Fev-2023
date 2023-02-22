using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePlace : MonoBehaviour
{
    public GameObject bush;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        bush.SetActive(true);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerWoof>().notDetected == true)
        {

            bush.SetActive(true);
        }

        else
        {
            bush.SetActive(false);
        }
    }

    
}
