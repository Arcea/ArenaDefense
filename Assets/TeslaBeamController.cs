using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaBeamController : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {

    }

    public void Connect(GameObject enemy)
    {
        Stretch(this.gameObject,
            this.transform.position,
            enemy.transform.position,
            false);
    }

    public void Stretch(GameObject _sprite, Vector3 _initialPosition, Vector3 _finalPosition, bool _mirrorZ)
    {
        Vector3 centerPos = (_initialPosition + _finalPosition) / 2f;
        _sprite.transform.position = centerPos;
        Vector3 direction = _finalPosition - _initialPosition;
        direction = Vector3.Normalize(direction);
        _sprite.transform.right = direction;
        if (_mirrorZ) _sprite.transform.right *= -1f;
        Vector3 scale = new Vector3(1, 1, 1);
        scale.x = Vector3.Distance(_initialPosition, _finalPosition);
        _sprite.transform.localScale = scale;
    }

}