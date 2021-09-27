using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManagerFlyweight : StateStrategy
{
    [Header("State Properties")]
    [SerializeField] private State currentState = State.startUp;
    public State CurrentState { get => currentState; }
    [SerializeField] private State nextState = State.startUp;
    [Header("Attack Script Properties")]
    [SerializeField] private EnemyShoot attackScript = null;
    [SerializeField] private Vector3 spawnOffset = Vector3.zero;
    [SerializeField] private Sprite bulletSprite = null;
    [SerializeField] private int bulletAmount = 1;
    [SerializeField] private float bulletSpacing = 1f;
    [Header("Move Script Properties")]
    [SerializeField] private MovementStrategy moveScript = null;
    [SerializeField] private float speed = 10f;
    [Space(10)]
    [SerializeField] private List<MonoBehaviour> otherScripts = new List<MonoBehaviour>();

    private void Awake()
    {
        if(attackScript != null)
        {
            attackScript.SpawnOffset = spawnOffset;
            attackScript.BulletSprite = bulletSprite;
            attackScript.BulletAmount = bulletAmount;
            attackScript.BulletSpacing = bulletSpacing;
        }
        if (moveScript != null)
            moveScript.Speed = speed;
    }
    private void OnEnable()
    {
        for (int i = 0; i < otherScripts.Count; i++)
            otherScripts[i].enabled = true;
        if(attackScript != null)
            attackScript.enabled = true;
        if (moveScript != null)
            moveScript.enabled = true;
    }
    private void OnDisable()
    {
        stateMachine.ChangeState(nextState);
        for (int i = 0; i < otherScripts.Count; i++)
            otherScripts[i].enabled = false;
        if (attackScript != null)
            attackScript.enabled = false;
        if (moveScript != null)
            moveScript.enabled = false;
    }
}
