using System.Collections;
using System.Collections.Generic;

public abstract class EnergyWeapon : IWeapon
{
    public float Charge { get; set; }
    public int FireRate { get; set; }

    public abstract void Fire();

    public abstract void Reload();
}