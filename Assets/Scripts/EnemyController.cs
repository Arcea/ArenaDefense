using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float speed;

    private GameObject[] players;
    private List<Transform> targets = new List<Transform>();

    private NavMeshAgent agent;

    private Transform closestTarget;
    private float closestDistance;

    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        
        for (int i = 0; i < players.Length; i++)
        {
            targets.Add(players[i].GetComponent<Transform>());
        }

        closestTarget = targets[0];
        closestDistance = Vector2.Distance(transform.position, targets[0].position);


        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.Warp(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform target in targets)
        {
            float distance = Vector2.Distance(transform.position, target.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTarget = target;
            }
        }

        agent.SetDestination(closestTarget.transform.position);
    }
}
