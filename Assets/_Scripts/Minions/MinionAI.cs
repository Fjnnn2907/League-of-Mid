using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionAI : MonoBehaviour
{
    public NavMeshAgent agent;
    private Transform currentTarget;
    public string enemyTag = "";
    public string towerTag = "";

    public float stopDistance = 2;
    public float aggroRange = 5f;
    public float targetSwitchInterval = 2;

    private float timeSinceLastTargetSwtich = 0;

    public bool isDeah = false;
    [SerializeField] protected Stats stats;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        FindAndSetTarget();
    }
    private void Update()
    {
        this.CheckDeah();
        if(isDeah) return;
        timeSinceLastTargetSwtich += Time.deltaTime;

        if(timeSinceLastTargetSwtich >= targetSwitchInterval)
        {
            CheckAndSwitchTargets();
            timeSinceLastTargetSwtich = 0;
        }

        if(currentTarget != null)
        {
            Vector3 diractionToTarget = currentTarget.position - transform.position;

            Vector3 stoppingPosition = currentTarget.position - diractionToTarget.normalized * stopDistance;

            agent.SetDestination(stoppingPosition);
        }
    }
    private void CheckAndSwitchTargets()
    {
        GameObject[] enemyMinions = GameObject.FindGameObjectsWithTag(enemyTag);
        Transform closestEnemyMinion = GetClosestObjectRadius(enemyMinions, aggroRange);

        if(closestEnemyMinion != null)
        {
            currentTarget = closestEnemyMinion;
        }
        else
        {
            GameObject[] tower = GameObject.FindGameObjectsWithTag(towerTag);
            currentTarget = GetClosesObject(tower);
        }
    }

    private Transform GetClosestObjectRadius(GameObject[] objects, float radius)
    {
     
        float closestDistance = Mathf.Infinity;
        Transform closestObject = null;
        Vector3 currentPosition = this.transform.position;

        foreach(GameObject obj in objects)
        {
            float distance = Vector3.Distance(currentPosition, obj.transform.position);

            if(distance < closestDistance && distance <= radius)
            {
                closestDistance = distance;
                closestObject = obj.transform;
            }
        }
        return closestObject;
    }
    private Transform GetClosesObject(GameObject[] objects)
    {
        float closestDistance = Mathf.Infinity;
        Transform closestObject = null;
        Vector3 currentPosition = this.transform.position;

        foreach(GameObject obj in objects)
        {
            float distance = Vector3.Distance(currentPosition, obj.transform.position);

            if(distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = obj.transform;
            }
        }


        return closestObject;
    }

    private void FindAndSetTarget()
    {
        GameObject[] enemyMinions = GameObject.FindGameObjectsWithTag(enemyTag);
        Transform closestEnemyMinion = GetClosestObjectRadius(enemyMinions,aggroRange);

        if(closestEnemyMinion != null)
        {
            currentTarget = closestEnemyMinion;
        }
        else
        {
            GameObject[] tower = GameObject.FindGameObjectsWithTag(towerTag);

            currentTarget = GetClosesObject(tower);
        }
    }
    public void CheckDeah()
    {
        if(stats.health <= 0 && !isDeah)
        {
            isDeah = true;  
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
            FarmManager.instance.AddCount(1);
            CointManager.instance.AddCoint(20);
            ExpManager.instance.AddExp(10);
            // them :D
            KillEnemy.Instance.AddKill(1);
        }
        
    }
}
