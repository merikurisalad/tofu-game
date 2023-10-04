using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TofuStateManager : MonoBehaviour
{
    TofuBaseState currentState;
    TofuIdleState IdleState = new TofuIdleState();
    TofuJumpState JumpState = new TofuJumpState();
    TofuReceiveState ReceiveState = new TofuReceiveState();
    TofuShowerState ShowerState = new TofuShowerState();

    // Start is called before the first frame update
    void Start()
    {
        // starting state for the state machine
        currentState = IdleState;
        // "this" is a reference to the context (this EXACT Monobehavior script)
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
