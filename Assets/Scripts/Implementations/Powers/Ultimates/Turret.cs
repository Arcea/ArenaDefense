using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Power
{
    public Turret()
    {
        this.Type = PowerType.Ultimate;
        this.Cooldown = 500f; //TBD
    }

    public override void Activate()
    {
        GameObject newPlaceable = Instantiate((GameObject)Resources.Load("Turret"), new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + Vector3.right * 4, this.transform.rotation);
        newPlaceable.GetComponentInChildren<TurretPlaceable>().lifeTime = 10;
    }
}