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

    //Fire controls, added for completness sake. Might need to be moved
    public string PrimaryFire = "ButtonA_P1";
    public string SpecialPower = "Fire2_P1";

    public GameObject weapon;
 
    // Start is called before the first frame update
    void Start()
    {
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
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        float trigger = Input.GetAxis("Trigger_P1");

        if (trigger != 0)
        {
            Debug.Log("Primary Fire");
            Shoot();
        }
        //if(Input.GetButtonDown(SpecialPower)){
        //    Debug.Log("UNLIMITED POWAH");
        //}
    }

    void Shoot()
    {
        weapon.GetComponent<PistolController>().Fire();
    }

}