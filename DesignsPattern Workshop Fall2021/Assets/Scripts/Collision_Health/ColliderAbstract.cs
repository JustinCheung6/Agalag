using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ColliderAbstract : CollisionStrategy
{

    protected abstract void OnEnteredCollision(GameObject c);

    protected void OnTriggerEnter2D(Collider2D c)
    {
        OnEnteredCollision(c.gameObject);
    }
    protected void OnCollisionEnter2D(Collision2D c)
    {
        OnEnteredCollision(c.gameObject);
    }
}
