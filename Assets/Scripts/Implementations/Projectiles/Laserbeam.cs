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

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        throw new System.NotImplementedException();
    }
}