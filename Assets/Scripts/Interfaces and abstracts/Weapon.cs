using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour //Inherits MonoBehaviour in order to make use of Instantiate in Fire();
{
    public abstract void Fire();
}