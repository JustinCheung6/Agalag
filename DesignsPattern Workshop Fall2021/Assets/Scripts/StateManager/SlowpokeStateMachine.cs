using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowpokeStateMachine : StateMachineStrategy, ITimeEvent
{
    [Header("Attack Script")]
    [SerializeField] private SlowpokeClientShoot atkScript = null;
    [SerializeField] private DirectionalMovement attackMoveScript = null;
    [Header("Move Script")]
    [SerializeField] private float moveDuration = 0.5f;
    [SerializeField] private DirectionalMovement moveScript = null;

    private int id = 0;
    private void Awake()
    {
        moveScript.enabled = false;
        atkScript.enabled = false;
        attackMoveScript.enabled = false;
    }
    private void OnEnable()
    {
        GetComponent<BounceOffWall>().OnCollide += Bounce;
        StartMachine();
    }
    private void OnDisable()
    {
        ChangeState(StateTypes.startUp);
        GetComponent<BounceOffWall>().OnCollide -= Bounce;
        id = (id >= 99) ? 0 : id + 1;
    }
    protected override void StartMachine()
    {
        ChangeState(StateTypes.attack);
    }
    protected override void ActivateState(StateTypes s)
    {
        switch (s)
        {
            case StateTypes.attack:
                atkScript.enabled = true;
                attackMoveScript.enabled = true;
                return;
            case StateTypes.move:
                moveScript.enabled = true;
                return;
        }
    }

    protected override void DeactivateState(StateTypes s)
    {
        switch (s)
        {
            case StateTypes.attack:
                atkScript.enabled = false;
                attackMoveScript.enabled = false;
                return;
            case StateTypes.move:
                moveScript.enabled = false;
                return;
        }
    }

    public void Activate(int id)
    {
        if (this.id != id)
            return;
        if(currentState == StateTypes.attack)
        {
            ChangeState(StateTypes.move);
            TimeManager.S.AddTimeEvent(this, moveDuration, this.id);
        }
        else
            ChangeState(StateTypes.attack);
    }

    public void Bounce()
    {
        if(currentState == StateTypes.attack)
            Activate(id);
    }
}
