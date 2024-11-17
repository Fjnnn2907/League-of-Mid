using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StudyEnemy : MonoBehaviour
{
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected Animator anim;
    protected float smoothTime = .1f;

    [SerializeField] protected float darius = 5f;
    [SerializeField] protected float maxDistace = 10f;

    [SerializeField] protected Transform target;

    [SerializeField] protected Vector3 backHome;
    [SerializeField] private Quaternion originalRotation;

    private float distance;
    private float distanceOriginal;
    public float stopingDistance;
    public bool isAttacking;

    [SerializeField] private float attackCooldown = 2f; 
    private float lastAttackTime = 0f;

    protected void Start()
    {
        backHome = this.transform.position;
        originalRotation = this.transform.rotation;
    }

    protected void Update()
    {
        this.DistanceMoveToPlayer();
        this.DistanceOriginal();
        this.CheckAnimation();

        if (Vector3.Distance(transform.position, backHome) < 0.1f)
            RotateToOriginal();
    }

    protected void DistanceOriginal()
    {
        distanceOriginal = Vector3.Distance(backHome, this.transform.position);
    }

    protected void DistanceMoveToPlayer()
    {
        distance = Vector3.Distance(target.position, this.transform.position);

        if (distance <= stopingDistance)
        {
            agent.isStopped = true;
            if (!isAttacking && Time.time >= lastAttackTime + attackCooldown)
            {
                isAttacking = true;
                lastAttackTime = Time.time;
                anim.SetTrigger("Attack");
            }
            return;
        }

        if (distance < darius && distanceOriginal < maxDistace)
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);
        }
        else if (distance > darius || distanceOriginal > maxDistace)
        {
            agent.isStopped = false;
            agent.SetDestination(backHome);
        }
    }

    protected void CheckAnimation()
    {
        float speed = agent.velocity.magnitude / agent.speed;
        anim.SetFloat("Speed", speed, smoothTime, Time.deltaTime);
    }

    protected void CheckAttackAnimation()
    {
        isAttacking = false;
        agent.isStopped = false;
    }

    private void RotateToOriginal()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.deltaTime * 20f);
    }
}
