using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementStrategy : MonoBehaviour
{
    [SerializeField] protected float speed;
    public float Speed { get => speed; }

    public abstract void Move();

    private void FixedUpdate()
    {
        Move();
    }

    public void SetSpeed(float s) { speed = s; }
}
