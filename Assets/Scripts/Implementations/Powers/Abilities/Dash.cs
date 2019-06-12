using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Power
{
    public GameObject player;

    public Dash()
    {
        this.Type = PowerType.Ability;
        this.Cooldown = 10f; //TBD
    }

    public override void Activate()
    {
        StartCoroutine(ActivateAbility());
    }

    IEnumerator ActivateAbility()
    {
        if (IsReady)
        {
            IsReady = false;
            player.GetComponent<PlayerController>().speed = 20;
            yield return new WaitForSeconds(0.5f);
            player.GetComponent<PlayerController>().speed = 5;
            yield return new WaitForSeconds(Cooldown);
            IsReady = true;
        }
    }
}