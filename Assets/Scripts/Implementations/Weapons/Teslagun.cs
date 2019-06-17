using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teslagun : EnergyWeapon
{
    public GameObject energyBall;
    public GameObject player;
    private bool allowFire = true;

    public override void Fire()
    {
        StartCoroutine(FireWeapon());
    }

    public Teslagun()
    {
        this.MaxCharge = 30;
        this.FireRate = 1;
    }

    IEnumerator FireWeapon()
    {
        if (CurrentCharge > 0 && allowFire)
        {
            allowFire = false;
            GameObject newBullet = Instantiate(energyBall, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), player.transform.rotation);
            CurrentCharge--;
            yield return new WaitForSeconds(FireRate);
            allowFire = true;
        }
    }

    public override float getCurrentAmmo()
    {
        return CurrentCharge;
    }

    public override float getMaxAmmo()
    {
        return MaxCharge;
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