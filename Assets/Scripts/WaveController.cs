using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveController : MonoBehaviour
{
    private int currentWave = 1;
    private GameObject[] spawners;
    private int playerCount;

    public int baseNumber = 20;
    public Text waveText;
    public Text remainingEnemies;

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
        waveText.text = "Current wave: " + currentWave;
        remainingEnemies.text = "Enemies remaining: " + GameObject.FindGameObjectsWithTag("enemy").Length;

        if(GameObject.FindGameObjectsWithTag("enemy").Length <= 0)
        {
            currentWave++;
            NextWave();
        }
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
    }
}
