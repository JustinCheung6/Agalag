using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementStrategy : MonoBehaviour
{
    [SerializeField] protected float speed;
    public float Speed { set => speed = value; }

    public abstract void Move();

    private void FixedUpdate()
    {
        Move();
    }
}
