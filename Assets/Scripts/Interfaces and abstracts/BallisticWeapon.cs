using System.Collections;
using System.Collections.Generic;

public abstract class BallisticWeapon : Weapon
{
    public int ClipSize { get; set; }
    public int FireRate { get; set; }

    public abstract void Reload();
}