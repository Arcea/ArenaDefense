using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Yup we went there.
public class ControlsController : MonoBehaviour
{

    public GameObject player;
    GameObject instantiatePlayer;
    private int playerCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delayCheck());
    }

    //Checking for new controllers
    IEnumerator delayCheck() {
        //Adding a delay so this won't get checked every second. Improving performance
         yield return new WaitForSecondsRealtime(2f);

        //Get Joystick Names
        string[] temp = Input.GetJoystickNames();
        
        //Check whether array contains anything
        if(temp.Length > 0)
        {
            //Iterate over every element
            for(int i =0; i < temp.Length; ++i)
            {
                //Check if the string is empty or not
                if(!string.IsNullOrEmpty(temp[i]) && i >= playerCount)
                {
                    //Not empty, controller temp[i] is connected
                    Debug.Log("Controller " + i + " is connected using: " + temp[i]);
                        //Debug.Log("Controller Length: " + temp.Length);
                        //Debug.Log("PlayerCount " +playerCount);
                        //Instantiate another gameobject here, since we cannot destroy the prefab. 
                        instantiatePlayer = Instantiate(player, transform.position, Quaternion.identity);
                        playerCount++;

                } else if(string.IsNullOrEmpty(temp[i]) && i < playerCount) { //Checking if playercount is higher then controllers. Then we remove a player
                    //Debug.Log(i);
                    //Debug.Log("PlayerCount: " + playerCount);
                    playerCount--;
                    Destroy(instantiatePlayer);
                }
                else
                {
                    //If it is empty, controller i is disconnected
                    //where i indicates the controller number

                    //Only use this for debug purposes
                    //Debug.Log("Controller: " + i + " is disconnected.");
                }
            }
        }

         StopAllCoroutines();
         StartCoroutine(delayCheck());
    }
}
