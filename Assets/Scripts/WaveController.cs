using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    private int currentWave = 0;
    private int EnemyNumbers = 0;
    public GameObject spawner;

    //TODO: Add Score based on enemies
    //TODO: Add max bas on spawner

    // Start is called before the first frame update
    void Start()
    {
        NextWave();
    }
     
    // Update is called once per frame
    void Update()
    {
        //Formula wavenumber * players or smth like that
        Debug.Log("Current wave: " + currentWave + " Enemy number: " + EnemyNumbers);
    }

    void NextWave()
    {
        currentWave++;


    }
}
