using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : BallisticWeapon
{
    public GameObject pistolBullet;
    public GameObject player;

    public override void Fire()
    {
        this.ClipSize = 10;
        if (this.ClipSize > 0)
        {
            Debug.Log("x" + player.transform.position.x);
            Debug.Log("y" + player.transform.position.y);
            GameObject newBullet = Instantiate(pistolBullet, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), player.transform.rotation);
            ClipSize--;
        }
    }

    public override void Reload()
    {
        throw new System.NotImplementedException();
    }
}