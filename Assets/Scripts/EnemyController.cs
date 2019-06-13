using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float speed = 50;

    private GameObject[] players;
    private List<Transform> targets = new List<Transform>();

    private NavMeshAgent agent;

    private Transform closestTarget;
    private float closestDistance;
    private Vector3 velocity;
    public bool stunned;

    // Start is called before the first frame update
    void Start()
    {
        stunned = false;
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
        agent.stoppingDistance = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = agent.velocity;
        foreach (Transform target in targets)
        {
            float distance = Vector2.Distance(transform.position, target.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTarget = target;
            }
        }

        if (stunned == false)
        {
           agent.isStopped = false;
           agent.SetDestination(closestTarget.transform.position);
        }
        else
        {
           agent.isStopped = true;
        }
    }
}
