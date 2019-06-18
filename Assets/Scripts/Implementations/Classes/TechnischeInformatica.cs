using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechnischeInformatica : PlayerClass
{
    private Weapon _pistol = new Pistol();
    private Power _frenzy = new FrenzyBomb();

    public TechnischeInformatica()
    {
        this.Name = "Cipher";
        this.Health = 10000f;
        this.Shield = 0f;
        this.Speed = 5f;
        this.Weapon = _pistol;
        this.Ability = _frenzy;
    }

    void Start()
    {
        _frenzy = gameObject.AddComponent<FrenzyBomb>();
    }
}