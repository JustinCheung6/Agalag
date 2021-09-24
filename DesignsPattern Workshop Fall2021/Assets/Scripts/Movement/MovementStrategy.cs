using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementStrategy : MonoBehaviour
{
    [SerializeField] protected float speed;

    public abstract void Move();
}
