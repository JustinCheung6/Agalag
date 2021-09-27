using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFlyweight : CollisionStrategy
{
    public ProjectileFlyweight(collisionGroups c)
    {
        cGroup = c;
    }

    protected void OnEnteredCollision(GameObject c)
    {
        HealthStrategy h = c.GetComponent<HealthStrategy>();

        if (h == null)
            return;

        if (h.CGroup == collisionGroups.Undecided)
            return;

        if(h.CGroup != this.cGroup)
        {
            h.Hurt();

        }

        Destroy();
    }

    public void Destroy()
    {
        this.gameObject.SetActive(false);
    }

    protected void OnTriggerEnter2D(Collider2D c)
    {
        OnEnteredCollision(c.gameObject);
    }
    protected void OnCollisionEnter2D(Collision2D c)
    {
        OnEnteredCollision(c.gameObject);
    }
}
