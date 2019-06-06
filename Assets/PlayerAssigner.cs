using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerAssigner : MonoBehaviour
{
    public string joinString = "ButtonA_P";

    private Player[] players;
    private List<int> controllers = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        players = FindObjectsOfType<Player>().OrderBy(p => p.playerNumber).ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 1; i <= 4; i++)
        {
            if (controllers.Contains(i))
            {
                // todo: go ready
                continue;
            }

            if (Input.GetButtonDown(joinString + i)){

                AssignController(i);
                break;
            }
        }
    }

    void AssignController(int controller)
    {
        Debug.Log(controllers.ToString());
        for (int i = 0; i < players.Length; i++)
        {
            if(players[i].GetController() == -1)
            {
                players[i].SetController(i);    
                controllers.Add(controller);
                break;
            }
        }
    }
}
