using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : BallisticWeapon
{
    public GameObject pistolBullet;
    public GameObject player;
    private bool allowFire = true;
    public override void Fire()
    {
        StartCoroutine(FireWeapon());
    }

    IEnumerator FireWeapon()
    {
        if (ClipSize > 0 && allowFire)
        {
            allowFire = false;
            GameObject newBullet = Instantiate(pistolBullet, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), player.transform.rotation);
            ClipSize--;
            yield return new WaitForSeconds(1f);
            allowFire = true;
        }
    }

    public override void Reload()
    {
        Invoke("ReloadWeapon", 2f);
    }

    private void ReloadWeapon()
    {
        ClipSize = 10;
    }
}