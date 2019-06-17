using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private NavMeshAgent agent;
    private string vertical = "Vertical_P";
    private string horizontal = "Horizontal_P";
    private string verticalRotation = "VerticalRotation_P";
    private string horizontalRotation = "HorizontalRotation_P";
    private string triggerAxis = "RightTrigger_P";

    //Fire controls, added for completness sake. Might need to be moved

    private string PrimaryFire = "ButtonA_P";
    private string SpecialPower = "LeftTrigger_P";
    private string Reload = "ButtonA_P";
    public float trigger;

    private Player currentPlayer;
    private int currentController;

    public PlayerClass playerClass;

    private bool paused = false;
    private Canvas menu;
    

    // Start is called before the first frame update
    void Start()
    {
        ReloadWeapon();
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Canvas>();
        menu.enabled = false;
    }

    public void SetController(int controller)
    {
        currentController = controller;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis(horizontal + currentController), Input.GetAxis(vertical + currentController), 0);
        transform.position += move * speed * Time.deltaTime;

        float angle = Mathf.Atan2(Input.GetAxis(horizontalRotation + currentController), Input.GetAxis(verticalRotation + currentController)) * Mathf.Rad2Deg;
        if (angle != 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

        if (Input.GetButtonDown(Reload + currentController))
        {
            ReloadWeapon();
        }

        trigger = Input.GetAxis(triggerAxis + currentController);
        float leftTrigger = Input.GetAxis(SpecialPower + currentController);
        

        if (trigger != 0)
        {
            Shoot();
        }
        else
        {
            GetComponentInChildren<PlayerClass>().GetComponentInChildren<Weapon>().StopFire();
        }

        if (leftTrigger != 0)
        {
            GetComponentInChildren<PlayerClass>().GetComponentInChildren<Power>().Activate();
        }
    }

    void Shoot()
    {
        GetComponentInChildren<PlayerClass>().GetComponentInChildren<Weapon>().Fire();
    }

    void ReloadWeapon()
    {
        GetComponentInChildren<PlayerClass>().GetComponentInChildren<Weapon>().Reload();
    }
}