using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleedTimedEffect : TimedEffect
{
    private int damage = 1;

    protected override void ApplyEffect()
    {
        Debug.Log(this.duration + "duration");
        Debug.Log(this.startTime + "Starttime");
        Debug.Log(this.repeatTime + "Repeatime");
        gameObject.GetComponent<CombatManager>().TakeDamage(damage);
        Debug.Log("I am bleeding now");
    }
}
