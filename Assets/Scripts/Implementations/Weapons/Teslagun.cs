using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teslagun : EnergyWeapon
{
    public Projectile energyBall;
    public GameObject player;
    private bool allowFire = true;

    public override void Fire()
    {
        StartCoroutine(FireWeapon());
    }

    void Start()
    {
        this.MaxCharge = 30;
        this.FireRate = 1;
    }

    IEnumerator FireWeapon()
    {
        if (CurrentCharge > 0 && allowFire)
        {
            allowFire = false;
            GameObject newBullet = Instantiate(energyBall.gameObject, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), player.transform.rotation);
            CurrentCharge--;
            yield return new WaitForSeconds(FireRate);
            allowFire = true;
        }
    }

    public override void ModifyDamage(float modifier)
    {
        energyBall.Damage *= modifier;
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