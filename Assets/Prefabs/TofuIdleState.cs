using UnityEngine;

public class TofuIdleState : TofuBaseState
{

    public override void EnterState(TofuStateManager tofu)
    {
        Debug.Log("Hello from the Idle State");
        tofu.TofuAnimator.Play("tofu_idle");
    }

    public override void UpdateState(TofuStateManager tofu)
    {
        if (Input.GetKey("space"))
        {
            tofu.SwitchState(tofu.JumpState);
        }
    }
}
