using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroesCombat : MonoBehaviour
{
    public enum HeroesAttackType { Melee,Ranged};
    public HeroesAttackType heroesAttackType;
    public GameObject targetedEnemy;
    public float attackRange;
    public float roteteSpeedForAttack;

    [SerializeField] protected Movement movement;
    public bool basicAtkIlde = false;
    public bool isHeroesAlive;
    public bool perForMeleeAttack = false;

    private void Update()
    {
        if(targetedEnemy != null)
        {
            if(Vector3.Distance(gameObject.transform.position,targetedEnemy.transform.position) > attackRange)
            {
                //movement.agent.SetDestination(targetedEnemy.transform.position);
                //movement.agent.stoppingDistance = attackRange;

                //Quaternion rotationToLookAt = Quaternion.LookRotation(targetedEnemy.transform.position - movement.agent.velocity);
                //transform.rotation = Quaternion.Slerp(transform.rotation, rotationToLookAt, Time.deltaTime * 10f); // Tăng giảm hệ số để chỉnh tốc độ xoay
            }
        }
        else
        {
            if(heroesAttackType == HeroesAttackType.Melee)
            {
                if (perForMeleeAttack)
                {
                    Debug.Log("a");
                }
            }
        }
    }

}
