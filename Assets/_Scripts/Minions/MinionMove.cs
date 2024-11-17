using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionMove : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] float speed = 2f;
    [SerializeField] Transform target;
    private void Start()
    {
        agent.speed = speed;
    }
    private void Update()
    {
        agent.SetDestination(target.transform.position);
    }

}
