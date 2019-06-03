﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private NavMeshAgent agent;
    public string vertical;
    public string horizontal;

    //Fire controls, added for compleness sake. Might need to be moved
    public string PrimaryFire = "Fire1_P1";
    public string SpecialPower = "Fire2_P1";
 
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

        float primaryAttack = Input.GetAxis("Trigger_P1");

        if(primaryAttack != 0){
            Debug.Log("Primary Fire");
        }
        //if(Input.GetButtonDown(SpecialPower)){
        //    Debug.Log("UNLIMITED POWAH");
        //}
    }

}