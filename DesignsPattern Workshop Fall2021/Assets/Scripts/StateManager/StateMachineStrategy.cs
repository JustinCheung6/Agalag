using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachineStrategy : MonoBehaviour
{
    public enum StateTypes
    {
        startUp,
        move,
        attack
    }
    [SerializeField]protected StateTypes currentState = StateTypes.startUp;

    protected abstract void StartMachine();

    protected virtual void ChangeState(StateTypes newState)
    {
        if (currentState != StateTypes.startUp)
            DeactivateState(currentState);
        currentState = newState;
        if (newState != StateTypes.startUp)
            ActivateState(currentState);
    }

    protected abstract void ActivateState(StateTypes s);
    protected abstract void DeactivateState(StateTypes s);
}
