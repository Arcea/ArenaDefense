using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CharacterSelectController : MonoBehaviour
{
    private Player[] players;
    private bool allReady
    {
        get
        {
            foreach (Player player in players)
            {
                if (!player.IsReady() && player.GetController() != -1)
                {
                    return false;
                }
            }

            return true;
        }
    }
    
    void Start()
    {
        players = FindObjectsOfType<Player>().OrderBy(p => p.playerNumber).ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (allReady)
        {
            foreach (Player player in players)
            {
                if (player.PressedStart()) {
                    Assets.SceneTransfer.players = players;
                    UnityEngine.SceneManagement.SceneManager.LoadScene(1);
                }
            }
        }
    }


}
