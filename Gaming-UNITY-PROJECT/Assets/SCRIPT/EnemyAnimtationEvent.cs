using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimtationEvent : MonoBehaviour
{
    public void Stop()
    {
        GetComponentInParent<EnemyPatrol>().stopMove();
    }

    public void GO()
    {

        GetComponentInParent<EnemyPatrol>().goMove();
    }
}
