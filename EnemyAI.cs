using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveToPlayer()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        agent.SetDestination(target.position);
    }

    void Update()
    {
        MoveToPlayer();
    }
}
