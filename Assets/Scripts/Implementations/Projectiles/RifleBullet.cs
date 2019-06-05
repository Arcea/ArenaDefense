using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleBullet : Projectile
{
    public RifleBullet()
    {
        DamageType = DamageType.Normal;
        //To be changed later.
        Damage = 15;
        Speed = 3f;
    }

    //TODO: Implement this.
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        throw new System.NotImplementedException();
    }
}