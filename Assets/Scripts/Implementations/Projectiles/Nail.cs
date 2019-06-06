using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nail : Projectile
{
    public Nail()
    {
        DamageType = DamageType.Piercing;
        //To be changed later.
        Damage = 20;
        Speed = 1.5f;
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        throw new System.NotImplementedException();
    }
}