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

    protected bool isDeah = false;
    [SerializeField] protected Stats stats;
    [SerializeField] private float attackCooldown = 2f; 
    private float lastAttackTime = 0f;


    protected void Start()
    {
        backHome = this.transform.position;
        originalRotation = this.transform.rotation;
    }

    protected void Update()
    {
        this.CheckIsDeah();
        if(this.isDeah) return;
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
        if (isDeah) return; // Nếu đã chết, không làm gì nữa.

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
        if (isDeah) return; // Không chỉnh sửa hoạt ảnh nếu đã chết.

        float speed = agent.velocity.magnitude / agent.speed;
        anim.SetFloat("Speed", speed, smoothTime, Time.deltaTime);
    }

    protected void CheckAttackAnimation()
    {
        isAttacking = false;
        agent.isStopped = false;
    }
    protected void CheckDamage()
    {
        if (!target.gameObject) return;
        stats.TakeDamge(target.gameObject, stats.damgage);
    }
    public void CheckIsDeah()
    {
        if (stats.health <= 0 && !isDeah)
        {
            anim.SetTrigger("Deah");
            isDeah = true;

            // Ngừng mọi hành vi di chuyển và tấn công
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
            isAttacking = false;

            // Thêm logic nếu cần, ví dụ tăng điểm số
            FarmManager.instance.AddCount(2);
            CointManager.instance.AddCoint(50);
            ExpManager.instance.AddExp(50);
        }
    }
    private void RotateToOriginal()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.deltaTime * 20f);
    }

}
