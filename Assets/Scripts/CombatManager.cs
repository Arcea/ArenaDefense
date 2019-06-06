﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 10000;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(health + "Health of enemy");
    }

    public void TakeDamage(int damage)
    {
        if (health - damage <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            health -= damage;
        }
    }
}