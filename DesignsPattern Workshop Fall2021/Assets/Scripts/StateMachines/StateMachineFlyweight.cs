using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineFlyweight : StateStrategy
{
    //State Machine Setup
    [SerializeField] private List<StateManagerFlyweight> stateManagers = new List<StateManagerFlyweight>();
    private Dictionary<State, StateManagerFlyweight> states = new Dictionary<State, StateManagerFlyweight>();

    [SerializeField] private List<MonoBehaviour> constantScripts = new List<MonoBehaviour>();
    
    [SerializeField] private State startingState = State.startUp;
    protected State currentState = State.startUp;

    private void Awake()
    {
        stateMachine = this;

        for(int i = 0; i < stateManagers.Count; i++)
        {
            stateManagers[i].StateMachine = this;
            states.Add(stateManagers[i].CurrentState, stateManagers[i]);
        }
    }
    private void OnEnable()
    {
        for (int i = 0; i < constantScripts.Count; i++)
            constantScripts[i].enabled = true;
        ChangeState(startingState);
    }
    private void OnDisable()
    {
        for (int i = 0; i < constantScripts.Count; i++)
            constantScripts[i].enabled = false;
        ChangeState(State.startUp);
    }

    public void ChangeState(State e)
    {
        if (currentState != State.startUp)
        {
            states[e].gameObject.SetActive(true);
        }

        currentState = e;

        if (e != State.startUp)
        {
            states[e].gameObject.SetActive(false);
        }
    }

}
