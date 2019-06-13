using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeable : MonoBehaviour
{
    public float lifeTime;

    public Transform pos;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", lifeTime);
        this.transform.position = pos.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
