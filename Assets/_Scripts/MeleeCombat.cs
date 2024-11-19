using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    [SerializeField] private Movement move;
    [SerializeField] private Stats stats;
    [SerializeField] Animator anim;

    [Header("Target")]
    public GameObject target;
    [Header("Melee Combat")]
    public bool perFormMeleeAttack = true;
    private float attackInterval;
    private float nextAttackTime = 0;

    private void Update()
    {
        attackInterval = stats.attackSpeed / ((500 + stats.attackSpeed) * 0.01f);

        target = move.targetEnemy;

        if(target != null  && perFormMeleeAttack && Time.time > nextAttackTime)
        {
            if(Vector3.Distance(this.transform.position, target.transform.position) <= move.stopingDistance)
            {
                StartCoroutine(MeleeAttackInterval());
            }
        }
    }
    private IEnumerator MeleeAttackInterval()
    {
        perFormMeleeAttack = false;
        anim.SetBool("isAttack", true);
        yield return new WaitForSeconds(attackInterval);
        if(target == null)
        {
            anim.SetBool("isAttack", false);
            perFormMeleeAttack=true;
        }
    }
    private void MeLeeAttack()
    {
        anim.SetBool("isAttack", false);
        nextAttackTime = Time.time + attackInterval;
        perFormMeleeAttack = true;
        stats.TakeDamge(target, stats.damgage);
    }
}
