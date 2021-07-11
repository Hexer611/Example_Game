using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Easy_Enemy : MonoBehaviour
{
    public Transform player;

    [SerializeField]
    NavMeshAgent self_agent;
    void Update()
    {
        self_agent.SetDestination(player.position);
    }
}
