using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharSelectController : MonoBehaviour
{
    public string Player1Join = "Fire1_P1";
    public string Player2Join = "Fire1_P2";
    public string Player3Join = "Fire1_P3";
    public string Player4Join = "Fire1_P4";

    //Cleanup
    public Text Player1Text;
    public Text Player2Text;
    public Text Player3Text;
    public Text Player4Text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(8))
        {
            Debug.Log("Starting game..");
            //UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }

        if(Input.GetButtonDown(Player1Join)){
            Debug.Log("Player 1 Joined");
            Player1Text.text = "Player 1 Joined!";
        }
        if(Input.GetButtonDown(Player2Join)){
            Debug.Log("Player 2 Joined");
            Player2Text.text = "Player 2 Joined!";
        }
        if(Input.GetButtonDown(Player3Join)){
            Debug.Log("Player 3 Joined");
            Player3Text.text = "Player 3 Joined!";
        }
        if(Input.GetButtonDown(Player4Join)){
            Debug.Log("Player 4 Joined");
            Player4Text.text = "Player 4 Joined!";
        }
    }
}
