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

        }
        else
        {
            timeBetween -= Time.deltaTime;
        }
    }
}
