using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private NavMeshAgent agent;
    public string vertical = "Vertical_P1";
    public string horizontal = "Horizontal_P1";
    public string verticalRotation = "VerticalRotation_P1";
    public string horizontalRotation = "HorizontalRotation_P1";
    public string triggerAxis = "Trigger_P1";

    //Fire controls, added for completness sake. Might need to be moved
    public string PrimaryFire = "ButtonA_P1";
    public string SpecialPower = "Fire2_P1";
    public float trigger;

    public Weapon weapon;
    

 
    // Start is called before the first frame update
    void Start()
    {
        nailGun.ClipSize = 5;
        //agent = GetComponent<NavMeshAgent>();
        //agent.updateRotation = false;
        //agent.updateUpAxis = false;


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
            nailGun.Reload();
            weapon.Reload();
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
        //if(Input.GetButtonDown(SpecialPower)){
        //    Debug.Log("UNLIMITED POWAH");
        //}
    }

    void Shoot()
    {
        weapon.Fire();
    }

}