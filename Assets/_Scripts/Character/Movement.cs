using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    protected NavMeshAgent agent;

    [Header("Target")]
    [SerializeField] private LayerMask layerMask;
    public GameObject targetEnemy;
    public float stopingDistance;

    protected void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    protected virtual void Update()
    {
        ClickToMove();
        StopHeroes();
        RotateTowardsMovementDirection();
    }

    protected void ClickToMove()
    {
        if (Input.GetMouseButton(1)) // Nhấp chuột phải
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag("Ground"))
                {
                    MoveToPosition(hit.point);
                }
                else if (hit.collider.CompareTag("Enemy"))
                {
                    MoveToEnemy(hit.collider.gameObject);
                }
            }
        }

        if (targetEnemy != null)
        {
            if (Vector3.Distance(transform.position, targetEnemy.transform.position) > stopingDistance)
            {
                agent.SetDestination(targetEnemy.transform.position);
            }
        }
    }

    private void MoveToPosition(Vector3 position)
    {
        agent.SetDestination(position);
        agent.stoppingDistance = 0;
        agent.isStopped = false;

        if (targetEnemy != null)
            targetEnemy = null;
    }

    private void MoveToEnemy(GameObject enemy)
    {
        targetEnemy = enemy;
        agent.SetDestination(targetEnemy.transform.position);
        agent.stoppingDistance = stopingDistance;
        Rotation(targetEnemy.transform.position);
    }

    private void RotateTowardsMovementDirection()
    {
        // Xoay hướng khi đang di chuyển
        if (agent.velocity.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(agent.velocity.normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }
    private void Rotation(Vector3 lookAtPosition)
    {
            Quaternion rotationToLookAt = Quaternion.LookRotation(lookAtPosition - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationToLookAt, Time.deltaTime * 10f); // Tăng giảm hệ số để chỉnh tốc độ xoay

    }
    protected void StopHeroes()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            agent.isStopped = true;
            agent.ResetPath();
        }
    }
}
