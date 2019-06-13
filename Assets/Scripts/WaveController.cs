using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    private int currentWave = 1;
    private GameObject[] spawners;
    private int playerCount;

    public int baseNumber = 20;

    //TODO: Add Score based on enemies
    //TODO: Add max based on spawner

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(WaveCountDown);
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        playerCount = GameObject.FindGameObjectsWithTag("Player").Length;
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
        int totalEnemies = baseNumber * currentWave * playerCount;
        int enemiesPerSpawner = totalEnemies / spawners.Length;

        //Divide enemynumber by spawners
        foreach (GameObject item in spawners)
        {
            item.GetComponent<SpawnController>().Spawn(enemiesPerSpawner);
        }

        currentWave++;
    }

    void WaveCountDown()
    {
        Time.timeScale = 0;
        //TODO: Add countdown for next wave
        //TODO: Add score for next wave
    }
}
