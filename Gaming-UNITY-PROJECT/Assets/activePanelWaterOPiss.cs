using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activePanelWaterOPiss : MonoBehaviour
{

    public GameObject waterPanel;

    public GameObject pissPanel;
    // Start is called before the first frame update
    void Start()
    {


        waterPanel.SetActive(false);
        pissPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PissPanelOn()
    {

        waterPanel.SetActive(true);
    }

    public void WaterPanelOn()
    {

        pissPanel.SetActive(true);
    }

    public void OffPanels()
    {


        waterPanel.SetActive(false);
        pissPanel.SetActive(false);
    }
}
