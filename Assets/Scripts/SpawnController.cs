using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject enemy;

    public static float initialEnemyNumber = 2f;
    private float currentEnemies = 1f;

    void Update()
    {
        while(currentEnemies <= initialEnemyNumber)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            currentEnemies++;
        }
    }
}
