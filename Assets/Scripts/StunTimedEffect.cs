using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunTimedEffect : TimedEffect
{
    protected override void ApplyEffect()
    {
        gameObject.GetComponent<EnemyController>().stunned = true;
    }

    protected override void EndEffect()
    {
        gameObject.GetComponent<EnemyController>().stunned = false;
        CancelInvoke();
        Destroy(this);
    }
}
