using UnityEngine;

public class TofuPickupState : TofuBaseState
{
    private float pickupTime = 2f;
    private float pickupTimer = 0f;

    public override void EnterState(TofuStateManager tofu)
    {
        Debug.Log("Hello from the Pickup State");
        tofu.ItemSprite.sprite = tofu.ItemSpriteArray[2];
        tofu.ItemSprite.enabled = true;
        tofu.TofuAnimator.Play("tofu_pickup");
    }

    public override void UpdateState(TofuStateManager tofu)
    {
        pickupTimer += Time.deltaTime;
        if (pickupTimer >= pickupTime)
        {
            pickupTimer = 0f;
            tofu.ItemSprite.enabled = false;
            tofu.SwitchState(tofu.IdleState);
        }
    }
}
