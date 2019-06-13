using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : BallisticWeapon
{
    public GameObject rifleBullet;
    public GameObject player;
    private bool allowFire = true;

    public override void Fire()
    {
        StartCoroutine(FireWeapon());
    }

    void Start()
    {
        this.ClipSize = 30;
        this.FireRate = 0.10f;
    }

    IEnumerator FireWeapon()
    {
        if (ClipSize > 0 && allowFire)
        {
            GetComponent<AudioSource>().Play();
            allowFire = false;
            GameObject newBullet = Instantiate(rifleBullet, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), player.transform.rotation);
            ClipSize--;
            yield return new WaitForSeconds(FireRate);
            allowFire = true;
        }
    }

    public override void Reload()
    {
        Invoke("ReloadWeapon", 2f);
    }

    private void ReloadWeapon()
    {
        ClipSize = 30;
    }
}