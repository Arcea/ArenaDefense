using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private int inputNumber;

    // input strings


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (inputNumber == -1) return;

        
    }

    public void SetInputNumber(int numb)
    {
        this.inputNumber = numb;
    }
}
