using System.Collections;
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

    void Start()
    {
        this.MaxClipSize = 15;
        this.FireRate = 0.50f;
        this.CurrentClipSize = MaxClipSize;
    }

    IEnumerator FireWeapon()
    {
        if (CurrentClipSize > 0 && allowFire)
        {
            GetComponent<AudioSource>().Play();
            allowFire = false;
            GameObject newBullet = Instantiate(nail, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), player.transform.rotation);
            CurrentClipSize--;
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
        CurrentClipSize = MaxClipSize;
    }
}