using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ColliderAbstract : CollisionBase
{
    public delegate void OnCollision();
    public OnCollision OnCollide;

    public abstract void OnEnteredCollision(GameObject c);

    //Mini Strategy (function that multiple implements)
    protected void OnTriggerEnter2D(Collider2D c)
    {
        OnEnteredCollision(c.gameObject);
    }
    protected void OnCollisionEnter2D(Collision2D c)
    {
        OnEnteredCollision(c.gameObject);
    }
}
