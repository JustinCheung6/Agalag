using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateStrategy : MonoBehaviour
{
    protected StateMachineFlyweight stateMachine = null;
    public StateMachineFlyweight StateMachine { set => stateMachine = value; }

    public enum State
    {
        startUp,
        idle,
        attack,
        move
    }


}
