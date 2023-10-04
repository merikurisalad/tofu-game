using UnityEngine;

public abstract class TofuBaseState
{
    public abstract void EnterState(TofuStateManager tofu);

    public abstract void UpdateState(TofuStateManager tofu);
}
