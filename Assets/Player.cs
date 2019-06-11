using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Unity Editor
    public int playerNumber;
    public Text text;

    // Private
    private BaseCharacter character;
    private int controller = -1;
    private PlayerInput input;
    private bool ready = false;


    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetController(int controller)
    {
        this.controller = controller;
        input.SetInputNumber(controller);
        UpdateText();
    }

    public int GetController()
    {
        return this.controller;
    }

    void UpdateText()
    {
        text.text = "Player " + playerNumber + " Joined";
    }

    public bool IsReady()
    {
        return ready;
    }

    public bool PressedStart()
    {
        if (controller == -1) return false;
        if(Input.GetButtonDown("Start_P" + controller))
        {
            return true;
        }

        return false;
    }
}
