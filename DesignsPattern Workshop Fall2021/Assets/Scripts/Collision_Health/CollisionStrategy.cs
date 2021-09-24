using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollisionStrategy : MonoBehaviour
{
    public collisionGroups cGroup = collisionGroups.Undecided;

    public enum collisionGroups
    {
        Undecided = 0,
        Player = 1,
        Enemy = 2
    };
}
