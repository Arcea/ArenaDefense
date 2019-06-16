using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float coolDownUntilNextSwitch = 0.2f;
    public float coolDownUntilNextScroll = 0.05f;

    private int inputNumber = -1;
    private Player player;
    private bool canSwitchCharacter = true;

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
        if (Input.GetAxis("Horizontal_P" + inputNumber) > 0)
        {
            // right
            StartCoroutine(SwitchTargetRoutine(coolDownUntilNextSwitch, 1));
        }
        else if (Input.GetAxis("Horizontal_P" + inputNumber) < 0)
        {
            // left
            StartCoroutine(SwitchTargetRoutine(coolDownUntilNextSwitch, -1));
        }

        if (Input.GetAxis("VerticalRotation_P" + inputNumber) > 0)
        {
            // up
            StartCoroutine(ScrollRoutine(coolDownUntilNextSwitch, 1));
        }
        else if (Input.GetAxis("VerticalRotation_P" + inputNumber) < 0)
        {
            // down
            StartCoroutine(ScrollRoutine(coolDownUntilNextSwitch, -1));
        }
    }

    IEnumerator SwitchTargetRoutine(float duration, int direction)
    {
        if (canSwitchCharacter)
        {
            canSwitchCharacter = false;

            if (direction > 0)
            {
                GetComponentInChildren<CharacterScript>().NextSlide();
            }
            else
            {
                GetComponentInChildren<CharacterScript>().PreviousSlide();
            }

            yield return new WaitForSeconds(duration);
            canSwitchCharacter = true;
        }
        else
        {
            yield return new WaitForSeconds(0f);
        }
    }

    IEnumerator ScrollRoutine(float duration, int direction)
    {
        if (direction > 0)
        {
            GetComponentInChildren<CharacterScript>().ScrollLoreDown();
        }
        else
        {
            GetComponentInChildren<CharacterScript>().ScrollLoreUp();
        }

        yield return new WaitForSeconds(duration);
    }

    public void SetInputNumber(int numb)
    {
        this.inputNumber = numb;
    }
}
