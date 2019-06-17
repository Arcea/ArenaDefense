using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasergun : EnergyWeapon
{
    public Projectile laserBeam;
    public GameObject player;
    private GameObject newLaser;
    private AudioSource audioSource;

    public override void Fire()
    {
        if (CurrentCharge > 10)
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            }

            newLaser.SetActive(true);
            newLaser.transform.position = new Vector3(player.transform.position.x, player.transform.position.y,
                player.transform.position.z);
            newLaser.transform.rotation = player.transform.rotation;
            CurrentCharge -= 0.5f;
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
        this.audioSource = GetComponent<AudioSource>();
        this.MaxCharge = 125;
        this.FireRate = 1;
        newLaser = Instantiate(laserBeam.gameObject, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), player.transform.rotation);
        CurrentCharge = MaxCharge;
        newLaser.SetActive(false);
    }

    void Update()
    {
        if (player.GetComponent<PlayerController>().trigger == 0)
        {
            Debug.Log(CurrentCharge + "CurrentCharge");
            if (!newLaser.activeInHierarchy && CurrentCharge < MaxCharge)
            {
                CurrentCharge += Time.deltaTime * 12;
            }
        }
    }

    public override void ModifyDamage(float modifier)
    {
        laserBeam.Damage *= modifier;
        
    }

    public override void Reload()
    {
        //Invoke("ReloadWeapon", 2f);
    }

    private void ReloadWeapon()
    {
        CurrentCharge = MaxCharge;
    }
}