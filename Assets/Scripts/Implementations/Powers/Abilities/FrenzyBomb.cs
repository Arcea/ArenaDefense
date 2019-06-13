using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrenzyBomb : Power
{
    public FrenzyBomb()
    {
        this.Type = PowerType.Ability;
        this.Cooldown = 150f; //TBD
    }

    public override void Activate()
    {
        throw new System.NotImplementedException();
    }
}