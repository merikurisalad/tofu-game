using UnityEngine;

public class TofuIdleState : TofuBaseState
{
    public override void EnterState(TofuStateManager tofu)
    {
        Debug.Log("Hello from the Idle State");
    }

    public override void UpdateState(TofuStateManager tofu)
    {
        
    }
}
