using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RestState : IState
{
    StateMachine stateMachine;

    public RestState(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public void Init() {

    }

    public void Tick() {
        if (Mouse.current.leftButton.wasPressedThisFrame) {
            stateMachine.ChangeState(new WorkState(stateMachine));
        }
    }

    public void Deinit() {

    }
}
