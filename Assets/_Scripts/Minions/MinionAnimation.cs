using UnityEngine;

public class MinionAnimation : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] MinionAI minionAI;

    private bool deathTriggered = false;

    private void Update()
    {
        CheckAnimation();
    }

    public void CheckAnimation()
    {
        if (minionAI.isDeah)
        {
            if (!deathTriggered)
            {
                anim.SetTrigger("Deah");
                deathTriggered = true;
            }
            return; 
        }

        float speed = minionAI.agent.velocity.magnitude / minionAI.agent.speed;
        anim.SetFloat("Speed", speed, .8f, Time.deltaTime);
    }
}
