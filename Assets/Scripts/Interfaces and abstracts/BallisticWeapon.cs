using System.Collections;
using System.Collections.Generic;

public abstract class BallisticWeapon : IWeapon
{
    public int ClipSize { get; set; }
    public int FireRate { get; set; }

    public abstract void Fire();

    public abstract void Reload();
}