using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWaterSystem : MonoBehaviour
{
    [Header("Water")]
    public Image waterBar;
    public float water;
    public float maxWater;
    public float waterDown;
    public float timeWaitAfterDrink;

    [Header("Piss")]
    public Image pissBar;
    public float piss;
    public float maxPiss;
    public float pissUp, pissDown;
    public float timeWaitAfterPiss;

    bool piGrow, waterGoes, canPiss, pissing;

    bool triggerWater, triggerPiss;


    // Start is called before the first frame update
    void Start()
    {
        piss = 0;
        water = 0;
        waterGoes = false;
        canPiss = false;
        piGrow = false;
        //StartCoroutine(drinkWater());
    }

    // Update is called once per frame
    void Update()
    {
        waterBar.fillAmount = water / maxWater;

        pissBar.fillAmount = piss / maxPiss;

        if (Input.GetKeyDown(KeyCode.R) && water <=0 && triggerWater == true || Input.GetButtonDown("X") && water <= 0 && triggerWater == true)
        {
            StartCoroutine(drinkWater());
        }

        if(piGrow)
        {
            PissUpBehaviour();
            SpeedDown();
        }

        if(Input.GetKeyDown(KeyCode.C) && canPiss && triggerPiss == true || Input.GetButtonDown("Y") && canPiss && triggerPiss == true)
        {
            pissing = true;
        }

        if(pissing == true)
        {
            PissOut();
        }

        if(waterGoes)
        {
            WaterDownBehaviour();
        }
    }

    void SpeedDown()
    {
        GetComponent<PlayerMove>().speed -= pissUp * Time.deltaTime;
        if(GetComponent<PlayerMove>().speed <= GetComponent<PlayerMove>().normalSpeed)
        {
            GetComponent<PlayerMove>().speed = GetComponent<PlayerMove>().normalSpeed;
        }
    }

    void PissOut()
    {
        piss -= pissDown * Time.deltaTime;
        if (piss <= 0)
        {
            StartCoroutine(pissWater());
        }
    }
    void PissUpBehaviour()
    {
        if (piss < maxPiss)
        {
            piss += pissUp * Time.deltaTime;
        }

        if (piss >= maxPiss)
        {
            piss = maxPiss;
            piGrow = false;
            canPiss = true;
        }
    }

    void WaterDownBehaviour()
    {
        water -= waterDown * Time.deltaTime;
        if(water <= 0)
        {
            water = 0;
            waterGoes = false;
        }
    }

    IEnumerator pissWater()
    {
        piss = 0;
        pissing = false;
        canPiss = false;
        yield return new WaitForSeconds(timeWaitAfterPiss);
        waterGoes = true;
    }

    IEnumerator drinkWater()
    {
        water = maxWater;
        yield return new WaitForSeconds(timeWaitAfterDrink);
        piGrow = true;

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Water"))
        {
            triggerWater = true;
            other.GetComponent<activePanelWaterOPiss>().WaterPanelOn();
        }

        if (other.CompareTag("Piss"))
        {
            triggerPiss = true;
            other.GetComponent<activePanelWaterOPiss>().PissPanelOn();
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Piss") || other.CompareTag("Water"))
        {
            other.GetComponent<activePanelWaterOPiss>().OffPanels();
            triggerPiss = false;
            triggerWater = false;
        }
    }
}
