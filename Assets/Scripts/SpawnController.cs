using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject enemy;

    public float timeBetween;
    

    // Update is called once per frame
    void Update()
    {
        if (timeBetween <= 0)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            timeBetween = 1;
        }
        else
        {
            timeBetween -= Time.deltaTime;
        }
    }
}
