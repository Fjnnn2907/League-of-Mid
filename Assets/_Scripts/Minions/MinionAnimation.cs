using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionAnimation : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] MinionAI minionAI;

    private void Update()
    {
        this.CheckAnimaiton();
    }
    public void CheckAnimaiton()
    {
        float speed = minionAI.agent.velocity.magnitude / minionAI.agent.speed;
        anim.SetFloat("Speed", speed, .8f, Time.deltaTime); 
    }
}
