using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public SaveS save;
    public Transform spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            save.saving = 1;
            save.isLoad = 1;
            save.Lastposition = spawnPoint.position;
        }
    }
}
