using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private NavMeshAgent agent;
    public string vertical = "Vertical_P1";
    public string horizontal = "Horizontal_P1";
    public string verticalRotation = "VerticalRotation_P1";
    public string horizontalRotation = "HorizontalRotation_P1";
    public string triggerAxis = "RightTrigger_P1";

    //Fire controls, added for completness sake. Might need to be moved
    public string PrimaryFire = "ButtonA_P1";
    public string SpecialPower = "Fire2_P1";
    public string bButton = "ButtonB_P1";
    public float trigger;

    public Weapon weapon;
    public GameObject placeable;

    private bool paused = false;
    private Canvas menu;
    

 
    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Canvas>();
        menu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis(horizontal), Input.GetAxis(vertical), 0);
        transform.position += move * speed * Time.deltaTime;

        float angle = Mathf.Atan2(Input.GetAxis(horizontalRotation), Input.GetAxis(verticalRotation)) * Mathf.Rad2Deg;
        if (angle != 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

        if (Input.GetButtonDown(PrimaryFire))
        {
            weapon.Reload();
        }

        if (Input.GetButtonDown(bButton))
        {
            PlaceBuilding();
        }

        trigger = Input.GetAxis(triggerAxis);

        if (trigger != 0)
        {
            Debug.Log("Primary Fire");
            Shoot();
        }
        else
        {
            weapon.StopFire();
        }
    }

    void Shoot()
    {
        weapon.Fire();
    }

    void PlaceBuilding()
    {
        GameObject newPlaceable = Instantiate(placeable, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), this.transform.rotation);
        newPlaceable.GetComponent<Placeable>().lifeTime = 10;
    }

}