using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMFlyweight : StateStrategy
{
    [Header("State Properties")]
    [SerializeField] private State currentState = State.startUp;
    public State CurrentState { get => currentState; }
    [SerializeField] private State nextState = State.startUp;

    private void OnDisable()
    {
        stateMachine.ChangeState(nextState);
    }
}
