using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollisionStrategy : MonoBehaviour
{
    protected virtual void OnEnable()
    {
        if(cGroup == collisionGroups.Undecided)
            Debug.Log(gameObject.name + ": this gameObject is undecided [CollisionStrategy]");
    }

    [SerializeField] protected collisionGroups cGroup = collisionGroups.Undecided;

    public enum collisionGroups
    {
        Undecided = 0,
        Player = 1,
        Enemy = 2
    };

    public collisionGroups CGroup { get => cGroup; }
}
