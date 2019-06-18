using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldedDroneController : MonoBehaviour
{
    private GameObject circleTarget;
    private float RotateSpeed = 5f;
    private float Radius = 0.1f;

    private Vector2 _centre;
    private float _angle;

    // Update is called once per frame
    void Update()
    {
        _centre = transform.position;

        _angle += RotateSpeed * Time.deltaTime;
        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        transform.position = _centre + offset;
    }

    public void SetTarget(GameObject g) {
        this.circleTarget = g;
    }
}
