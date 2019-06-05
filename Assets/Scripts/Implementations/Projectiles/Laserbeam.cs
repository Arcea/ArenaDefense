using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laserbeam : Projectile
{
    public Laserbeam()
    {
        DamageType = DamageType.Piercing;
        //To be changed later.
        Damage = 7;
        Speed = 2.5f;
    }

    //TODO: Implement this.
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        throw new System.NotImplementedException();
    }
}