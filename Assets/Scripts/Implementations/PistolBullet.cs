using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBullet : Projectile
{
    public PistolBullet()
    {
        DamageType = DamageType.Bleeding;
        //To be changed later.
        Damage = 5;
        Speed = 2f;
    }

    //TODO: Implement this.
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        throw new System.NotImplementedException();
    }
}