using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private IState currentState;

    public void ChangeState(IState state) {
        if (currentState != null) {
            currentState.Deinit();
        }

        currentState = state;

        if (currentState != null) {
            currentState.Init();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null) {
            currentState.Tick();
        }
    }
}
