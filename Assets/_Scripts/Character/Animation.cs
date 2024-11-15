using UnityEngine;

public class Animation : Movement
{
    [SerializeField] protected Animator anim;

    protected float smoothTime = .1f;

    protected override void Update()
    {
        base.Update();

        this.CheckAnimation();
    }
    protected void CheckAnimation()
    {
        float speed = agent.velocity.magnitude/agent.speed;
        anim.SetFloat("Speed", speed, smoothTime, Time.deltaTime);
    }
}
