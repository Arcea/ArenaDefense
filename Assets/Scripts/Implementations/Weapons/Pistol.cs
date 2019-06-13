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

    void Start()
    {
        this.MaxClipSize = 10;
        this.FireRate = 1;
    }

    IEnumerator FireWeapon()
    {
        if (CurrentClipSize > 0 && allowFire)
        {
            GetComponent<AudioSource>().Play();
            allowFire = false;
            GameObject newBullet = Instantiate(pistolBullet, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), player.transform.rotation);
            CurrentClipSize--;
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
        CurrentClipSize = MaxClipSize;
    }
}