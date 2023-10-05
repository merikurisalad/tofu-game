using UnityEngine;

public class TofuJumpState : TofuBaseState
{
    private float jumpTime = 1f;
    private float jumpTimer = 0f;

    public override void EnterState(TofuStateManager tofu)
    {
        Debug.Log("Hello from the Jump State");
        tofu.TofuAnimator.Play("tofu_jump");
    }

    public override void UpdateState(TofuStateManager tofu)
    {
        jumpTimer += Time.deltaTime;
            if (jumpTimer >= jumpTime)
            {
                jumpTimer = 0f;
                tofu.SwitchState(tofu.IdleState);
            }
    }
}
