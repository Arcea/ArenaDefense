using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : Projectile
{
    public EnergyBall()
    {
        DamageType = DamageType.Stun;
        //To be changed later.
        Damage = 20;
        Speed = 5f;
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        throw new System.NotImplementedException();
    }
}