using System.Collections;
using System.Collections.Generic;

public abstract class EnergyWeapon : Weapon
{
    public float Charge { get; set; }
    public int FireRate { get; set; }

    public abstract void Reload();
}