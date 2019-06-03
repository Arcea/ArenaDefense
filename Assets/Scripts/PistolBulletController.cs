using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PistolBulletController : MonoBehaviour
{
    public float zAxis;
    private float speed = 0.4f;

    public Vector2 bulletDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += transform.forward * Time.deltaTime * speed;
    }
}
