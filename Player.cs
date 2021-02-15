using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public NavMeshAgent agent;
    public CombatBase combat;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CombatBase>();
    }

    private void MoveToPoint()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                agent.destination = hit.point;
            }
        }
    }

    private void AttackClosestEnemy()
    {
        if (Input.GetMouseButtonDown(1))
        {
            combat.TryAttack();
        }
    }
    private void Update()
    {
        MoveToPoint();
        AttackClosestEnemy();
    }
}
