using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineFlyweight : StateStrategy
{
    //State Machine Setup
    [SerializeField] private List<StateMFlyweight> stateScripts = new List<StateMFlyweight>();
    private Dictionary<State, StateMFlyweight> states = new Dictionary<State, StateMFlyweight>();
    
    [SerializeField] private State startingState = State.startUp;
    protected State currentState = State.startUp;
    public State CurrentState { get => currentState; }

    private void Awake()
    {
        stateMachine = this;

        for(int i = 0; i < stateScripts.Count; i++)
        {
            stateScripts[i].StateMachine = this;
            states.Add(stateScripts[i].CurrentState, stateScripts[i]);
        }
    }
    private void OnEnable()
    {
        ChangeState(startingState);
    }
    private void OnDisable()
    {
        ChangeState(State.startUp);
    }

    public void ChangeState(State e)
    {
        if (currentState != State.startUp)
        {
            states[currentState].gameObject.SetActive(false);
        }

        currentState = e;

        if (currentState != State.startUp)
        {
            states[currentState].gameObject.SetActive(true);
        }
    }
}
