using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthAbstract : CollisionStrategy
{
    [SerializeField] protected int healthPoints;

    public abstract void Hurt();

}
