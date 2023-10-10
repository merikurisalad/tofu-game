using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TofuStateManager : MonoBehaviour
{
    TofuBaseState currentState;
    public TofuIdleState IdleState = new TofuIdleState();
    public TofuJumpState JumpState = new TofuJumpState();
    public TofuReceiveState ReceiveState = new TofuReceiveState();
    public TofuShowerState ShowerState = new TofuShowerState();
    public TofuPickupState PickupState = new TofuPickupState();

    public SpriteRenderer TofuSprite;
    public Animator TofuAnimator;
    public SpriteRenderer ItemSprite;
    public Sprite[] ItemSpriteArray;

    public DialogueManager dialogueManager;
    public GameObject talkPanel;

    // Start is called before the first frame update
    void Start()
    {
        // starting state for the state machine
        currentState = IdleState;
        // assign reference
        TofuSprite = this.GetComponent<SpriteRenderer>(); // not used for now
        TofuAnimator = this.GetComponent<Animator>();
        ItemSprite.enabled = false;

        // "this" is a reference to the context (this EXACT Monobehavior script)
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(TofuBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public void OnMainButtonClicked()
    {
        SwitchState(ShowerState);
    }

    public void OnAdventureButtonClicked()
    {
        SwitchState(ReceiveState);
    }

    public void OnWorkButtonClicked()
    {
        SwitchState(PickupState);
    }
}
