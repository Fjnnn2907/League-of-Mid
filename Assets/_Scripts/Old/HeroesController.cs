using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroesController : MonoBehaviour
{
    const string IDLE = "Idle";
    const string WALK = "Move";
    const string ATTACK = "Attack";

    ActionInput input;
    NavMeshAgent agent;
    Animator animator;

    [Header("Movement")]
    [SerializeField] ParticleSystem clickEffect;
    [SerializeField] LayerMask clickableLayers;
    [SerializeField] LayerMask enemyLayers; // Lớp xác định enemy

    float lookRotationSpeed = 8f;
    Transform target; // Đối tượng để lưu enemy khi được chọn

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        input = new();
        AssignInputs();
    }

    void AssignInputs()
    {
        input.Main.Move.performed += ctx => ClickToMove();
    }

    void ClickToMove()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            // Kiểm tra xem vị trí click là enemy hay không
            if ((enemyLayers & (1 << hit.collider.gameObject.layer)) != 0)
            {
                target = hit.collider.transform; // Đặt target là enemy
                agent.destination = target.position; // Di chuyển tới enemy
            }
            else if ((clickableLayers & (1 << hit.collider.gameObject.layer)) != 0)
            {
                target = null; // Xóa target nếu click vào chỗ khác
                agent.destination = hit.point;
                if (clickEffect != null)
                { Instantiate(clickEffect, hit.point + new Vector3(0, 0.1f, 0), clickEffect.transform.rotation); }
            }
        }
    }

    void OnEnable()
    { input.Enable(); }

    void OnDisable()
    { input.Disable(); }

    void Update()
    {
        if (target != null && Vector3.Distance(transform.position, target.position) <= agent.stoppingDistance)
        {
            AttackTarget(); // Tấn công enemy nếu đến gần
        }
        else
        {
            FaceTarget();
            SetAnimations();
        }
    }

    void FaceTarget()
    {
        if (agent.remainingDistance <= agent.stoppingDistance && target == null) return;

        Vector3 direction = (agent.destination - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookRotationSpeed);
        }
    }

    void SetAnimations()
    {
        if (target != null && Vector3.Distance(transform.position, target.position) <= agent.stoppingDistance)
        {
            animator.Play(ATTACK); // Chuyển sang animation tấn công khi đến gần target
        }
        else if (agent.velocity == Vector3.zero)
        {
            animator.Play(IDLE); // Animation Idle
        }
        else
        {
            animator.Play(WALK); // Animation Move
        }
    }

    void AttackTarget()
    {
        // Tạm dừng và giữ nguyên vị trí khi tấn công
        agent.isStopped = true;

        // Triển khai logic tấn công ở đây, ví dụ như gây sát thương lên enemy
        // Sau đó, có thể thiết lập lại trạng thái di chuyển nếu cần
    }
}
