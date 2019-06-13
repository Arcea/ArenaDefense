﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasergun : EnergyWeapon
{
    public GameObject laserBeam;
    public GameObject player;
    private bool laserBeamActive = false;
    private GameObject newLaser;

    public override void Fire()
    {
        Debug.Log("Laser Rifle called ");
        if (CurrentCharge > 0)
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            }

            newLaser.SetActive(true);
            newLaser.transform.position = new Vector3(player.transform.position.x, player.transform.position.y,
                player.transform.position.z);
            newLaser.transform.rotation = player.transform.rotation;
            CurrentCharge--;
        }
        else
        {
            newLaser.SetActive(false);
        }
    }

    public override void StopFire()
    {
        newLaser.SetActive(false);
        GetComponent<AudioSource>().Stop();
    }

    void Start()
    {
        this.MaxCharge = 125;
        this.FireRate = 1;
        newLaser = Instantiate(laserBeam, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), player.transform.rotation);
        newLaser.SetActive(false);
    }

    public override void Reload()
    {
        Invoke("ReloadWeapon", 2f);
    }

    private void ReloadWeapon()
    {
        CurrentCharge = MaxCharge;
    }
}