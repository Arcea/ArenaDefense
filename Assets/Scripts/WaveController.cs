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

    //Wave countdown variables; might need seperation
    private Canvas nextWavePanel;
    public Text waveCount;
    public Text countdown;
    float countDownTime;

    //TODO: Add Score based on enemies
    //TODO: Add max based on spawner

    // Start is called before the first frame update
    void Start()
    {
        nextWavePanel = GameObject.FindGameObjectWithTag("WaveMenu").GetComponent<Canvas>();
        nextWavePanel.enabled = false;
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
        if(currentWave != 1)
        {
            Time.timeScale = 0;
            StartCoroutine(Countdown());
        }
        
        int totalEnemies = baseNumber * currentWave * playerCount;
        int enemiesPerSpawner = totalEnemies / spawners.Length;

        //Divide enemynumber by spawners
        foreach (GameObject item in spawners)
        {
            item.GetComponent<SpawnController>().Spawn(enemiesPerSpawner);
        }

        
    }

    IEnumerator Countdown()
    {
        nextWavePanel.enabled = true;
        waveCount.text = "Wave " + currentWave + " incoming";

        for (int i = 5; i > 0; i--)
        {
            countdown.text = "" + i;
            yield return new WaitForSecondsRealtime(1);
        }

        
        //for (countDownTime = 5; countDownTime > 0; countDownTime -= Time.deltaTime)
        //{
        ///    yield return null;
        //    countdown.text = "" + (int)countDownTime;
        //}

        nextWavePanel.enabled = false;
        Time.timeScale = 1;
    }
}
