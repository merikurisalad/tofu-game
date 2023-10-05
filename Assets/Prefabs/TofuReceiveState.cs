using UnityEngine;

public class TofuReceiveState : TofuBaseState
{
    private float receiveTime = 2f;
    private float receiveTimer = 0f;

    public override void EnterState(TofuStateManager tofu)
    {
        Debug.Log("Hello from the Receive State");
        tofu.ItemSprite.sprite = tofu.ItemSpriteArray[1];
        tofu.ItemSprite.enabled = true;
        tofu.TofuAnimator.Play("tofu_receive_bigger");
    }

    public override void UpdateState(TofuStateManager tofu)
    {
        receiveTimer += Time.deltaTime;
        if (receiveTimer >= receiveTime)
        {
            receiveTimer = 0f;
            tofu.ItemSprite.enabled = false;
            tofu.SwitchState(tofu.IdleState);
        }        
    }
}
