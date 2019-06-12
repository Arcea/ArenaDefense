using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneShield : Power
{
    public GameObject player;
    public GameObject sprite;

    public DroneShield()
    {
        this.Type = PowerType.Ultimate;
        this.Cooldown = 500f; //TBD
    }

    public override void Activate()
    {
        StartCoroutine(ActivateUltimate());
    }

    IEnumerator ActivateUltimate()
    {
        if (IsReady)
        {
            IsReady = false;
            //Do Ultimate
            yield return new WaitForSeconds(Cooldown);
            IsReady = true;
        }
    }
}