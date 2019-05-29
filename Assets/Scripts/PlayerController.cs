using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 targetPos;
    public float YIncrement;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Basic movement code; should be updated for smoother movement
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + YIncrement);
        } else if ( Input.GetKey(KeyCode.DownArrow))
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - YIncrement);
        } else if ( Input.GetKey(KeyCode.LeftArrow))
        {
            targetPos = new Vector2(transform.position.x - YIncrement, transform.position.y);
        }
         else if ( Input.GetKey(KeyCode.RightArrow))
        {
            targetPos = new Vector2(transform.position.x + YIncrement, transform.position.y);
        }
    }
}