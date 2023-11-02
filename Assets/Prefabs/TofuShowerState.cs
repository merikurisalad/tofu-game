using UnityEngine;

public class TofuShowerState : TofuBaseState
{
    private float showerTime = 2f;
    private float showerTimer = 0f;

    public override void EnterState(TofuStateManager tofu)
    {
        Debug.Log("Hello from the Shower State");

        tofu.ItemSprite.sprite = tofu.ItemSpriteArray[0];
        tofu.ItemSprite.enabled = true;
        tofu.TofuAnimator.Play("tofu_shower");
        
        // add dialogue
        tofu.talkPanel.SetActive(true);
        tofu.dialogueManager.dialogues = new string[]
        {
            "Tofu showered! It's a bit soggy now..."
        };
        tofu.dialogueManager.ShowNextDialogue();
    }

    public override void UpdateState(TofuStateManager tofu)
    {
        showerTimer += Time.deltaTime;
        if (showerTimer >= showerTime)
        {
            showerTimer = 0f;
            tofu.ItemSprite.enabled = false;
            tofu.SwitchState(tofu.IdleState);
        }
    }
}