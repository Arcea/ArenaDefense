﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nailgun : BallisticWeapon
{
    public GameObject nail;
    public GameObject player;
    private bool allowFire = true;
    public override void Fire()
    {
        StartCoroutine(FireWeapon());
    }

    IEnumerator FireWeapon()
    {
        if (MaxClipSize > 0 && allowFire)
        {
            allowFire = false;
            GameObject newBullet = Instantiate(nail, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), player.transform.rotation);
            MaxClipSize--;
            yield return new WaitForSeconds(4f);
            allowFire = true;
        }
    }

    public override void Reload()
    {
        Invoke("ReloadWeapon", 2f);
    }

    private void ReloadWeapon()
    {
        MaxClipSize = 5;
    }
}