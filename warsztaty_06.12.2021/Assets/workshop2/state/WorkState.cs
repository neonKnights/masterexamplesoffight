using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkState : IState
{
    private StateMachine stateMachine;
    private float time;

    public WorkState(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

/*
    */
    public void Init() {
        stateMachine.transform.localScale = 2*Vector3.one;
    }

    public void Tick() {
        float deltaTime = Time.deltaTime;
        stateMachine.transform.Rotate(0, 20*deltaTime, 0);
        time += deltaTime;
        if (time > 3) {
            stateMachine.ChangeState(new RestState(stateMachine));
        }
    }

    public void Deinit() {
        stateMachine.transform.localScale = Vector3.one;
    }
    
    // tu może być jeszcze czange state to work e.t.c.:w
    
}