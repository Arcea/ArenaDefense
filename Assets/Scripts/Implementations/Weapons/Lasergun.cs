using System.Collections;
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
        if (Charge > 0)
        {
            newLaser.SetActive(true);
            newLaser.transform.position = new Vector3(player.transform.position.x, player.transform.position.y,
                player.transform.position.z);
            newLaser.transform.rotation = player.transform.rotation;
            Charge--;
        }
        else
        {
            newLaser.SetActive(false);
        }
    }

    public override void StopFire()
    {
        newLaser.SetActive(false);
    }

    void Start()
    {
        this.Charge = 125;
        this.FireRate = 0.10f;
        newLaser = Instantiate(laserBeam, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), player.transform.rotation);
        newLaser.SetActive(false);
    }

    public override void Reload()
    {
        Invoke("ReloadWeapon", 2f);
    }

    private void ReloadWeapon()
    {
        Charge = 125;
    }
}