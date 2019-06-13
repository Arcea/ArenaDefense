using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    private int currentWave = 0;
    private int EnemyNumbers = 0;
    public GameObject[] spawners;
    private float InitEnemies = SpawnController.initialEnemyNumber;

    //TODO: Add Score based on enemies
    //TODO: Add max based on spawner

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(WaveCountDown);
        spawners = GetComponents
        NextWave();
    }

    // Update is called once per frame
    void Update()
    {
        //Formula wavenumber * players or smth like that
        //Debug.Log("Current wave: " + currentWave + " Enemy number: " + EnemyNumbers);
    }

    void NextWave()
    {
        currentWave++;
        //Divide enemynumber by spawners
        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i].SetActive(true);
            SpawnController.initialEnemyNumber = 3f;
        }
    }

    void Spawn(int spawnIndex, int amount)
    {
        spawners[spawnIndex]
    }

    void WaveCountDown()
    {
        Time.timeScale = 0;
        //TODO: Add countdown for next wave
        //TODO: Add score for next wave
    }
}
