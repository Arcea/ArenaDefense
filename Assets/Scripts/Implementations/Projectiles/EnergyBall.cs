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

    //TODO: Implement this.
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        throw new System.NotImplementedException();
    }
}