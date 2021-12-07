using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerController : StateMachine
{
    void Awake() {
        this.ChangeState(new WorkState(this));
    }
}
