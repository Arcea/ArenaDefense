using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : BallisticWeapon
{
    public GameObject rifleBullet;
    private bool allowFire = true;

    public override void Fire()
    {
        StartCoroutine(FireWeapon());
    }

    void Start()
    {
        this.MaxClipSize = 30;
        this.FireRate = 0.10f;
    }

    IEnumerator FireWeapon()
    {
        Debug.Log(CurrentClipSize);
        if (CurrentClipSize > 0 && allowFire)
        {
            Debug.Log("Firing Rifle");
            GetComponent<AudioSource>().Play();
            allowFire = false;
            GameObject newBullet = Instantiate(rifleBullet, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), this.gameObject.transform.rotation);
            CurrentClipSize--;
            yield return new WaitForSeconds(FireRate);
            allowFire = true;
        }
    }

    public override void Reload()
    {
        var clip = Resources.Load("Audio/rifleReload") as AudioClip;
        GetComponent<AudioSource>().PlayOneShot(clip);
        Invoke("ReloadWeapon", 0.7f);
    }

    private void ReloadWeapon()
    {
        CurrentClipSize = 30;
    }
}