using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerType { Ability, Ultimate }

public abstract class Power
{
    public float Cooldown { get; set; }

    public PowerType Type { get; set; }

    public abstract void Activate();
}