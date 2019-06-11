using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private int inputNumber = -1;
    private Player player;

    // input strings


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputNumber == -1) return;
        if(Input.GetAxis("Horizontal_P" + inputNumber) > 0)
        {
            // right
            GetComponentInChildren<CharacterScript>().NextSlide();
        }
        if (Input.GetAxis("Horizontal_P" + inputNumber) < 0)
        {
            // left
            GetComponentInChildren<CharacterScript>().PreviousSlide();
        }
    }

    public void SetInputNumber(int numb)
    {
        this.inputNumber = numb;
    }
}
