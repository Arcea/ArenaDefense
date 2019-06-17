using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teslagun : EnergyWeapon
{
    public GameObject energyBall;
    public GameObject player;
    private bool allowFire = true;
    private bool isActive = false;

    public override void Fire()
    {
        StartCoroutine(FireWeapon());
    }

    void Start()
    {
        this.MaxCharge = 30;
        this.FireRate = 1;
        this.CurrentCharge = MaxCharge;
    }

    IEnumerator FireWeapon()
    {
        if (CurrentCharge > 0 && allowFire && !isActive)
        {
            allowFire = false;
            isActive = true;
            GameObject newBullet = Instantiate(energyBall, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), player.transform.rotation);
            CurrentCharge--;
            yield return new WaitForSeconds(FireRate);
            allowFire = true;
            isActive = false;
        }
    }

    void Update()
    {
        if (!isActive)
        {
            if (player.GetComponent<PlayerController>().trigger == 0)
            {
                Debug.Log(CurrentCharge + "CurrentCharge");
                if (CurrentCharge < MaxCharge)
                {
                    CurrentCharge += Time.deltaTime;
                }
            }
        }
    }

    public override void StopFire()
    {
        isActive = false;
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