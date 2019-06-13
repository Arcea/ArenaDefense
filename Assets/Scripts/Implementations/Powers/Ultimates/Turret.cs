using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Power
{
    public Turret()
    {
        this.Type = PowerType.Ultimate;
        this.Cooldown = 500f; //TBD
    }

    public override void Activate()
    {
        throw new System.NotImplementedException();
    }
}