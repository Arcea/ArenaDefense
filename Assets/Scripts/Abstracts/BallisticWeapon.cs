using System.Collections;
using System.Collections.Generic;

public abstract class BallisticWeapon : Weapon
{
    public int MaxClipSize { get; set; }
    public int CurrentClipSize { get; set; }
    public float FireRate { get; set; }
}