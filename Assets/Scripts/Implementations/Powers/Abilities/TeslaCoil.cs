using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaCoil : Power
{
    public TeslaCoil()
    {
        this.Type = PowerType.Ability;
        this.Cooldown = 100f; 
    }

    public override void Activate()
    {
        throw new System.NotImplementedException();
    }
}