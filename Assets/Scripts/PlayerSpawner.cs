using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("asdhksadhals");
        List<Player> players = Assets.SceneTransfer.players.Where(p => p.GetController() != -1).ToList();
        Debug.Log(players);
        int x = 145;
        foreach (Player player in players)
        {
            var variableForPrefab = (GameObject)Resources.Load(player.GetCharacter().subText.text, typeof(GameObject));
            GameObject obj = GameObject.Instantiate(variableForPrefab, transform.position, transform.rotation);
            obj.GetComponent<PlayerController>().SetController(player.GetController());
            obj.GetComponent<PlayerController>().SetUIPosition(x);
            x += 200;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
