using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacking : Power
{
    private GameObject mainCamera;
    private GameObject[] players;
    private float damageMultiplier = 2;

    public Hacking()
    {
        this.Type = PowerType.Ultimate;
        this.Cooldown = 10f; //TBD
    }

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    public override void Activate()
    {
        StartCoroutine(ActivateUltimate());
    }

    private IEnumerator ActivateUltimate()
    {
        if (IsReady)
        {
            IsReady = false;
            //Do ultimate
            var script = mainCamera.GetComponent<Kino.AnalogGlitch>();
            script.enabled = true;
            script.scanLineJitter = 0.35f;
            script.verticalJump = 0.135f;
            script.horizontalShake = 0.035f;
            script.colorDrift = 0.4f;

            //TODO: Give team damage boost
            foreach (var player in players)
            {
                var weapon = (player.GetComponentInChildren<Weapon>().GetComponent<MonoBehaviour>() as Weapon);
                weapon.ModifyDamage(damageMultiplier);
            }

            yield return new WaitForSeconds(1.5f);
            script.enabled = false;
            Debug.Log("Filter disabled");
            yield return new WaitForSeconds(8.5f);
            Debug.Log("Buff removed");

            //TODO: Remove team damage boost
            foreach (var player in players)
            {
                var weapon = (player.GetComponentInChildren<Weapon>().GetComponent<MonoBehaviour>() as Weapon);
                weapon.ModifyDamage(1 / damageMultiplier);
            }

            yield return new WaitForSeconds(Cooldown);
            IsReady = true;
        }
    }
}