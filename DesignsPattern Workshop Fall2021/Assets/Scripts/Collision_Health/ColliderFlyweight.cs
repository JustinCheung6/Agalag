using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderFlyweight : CollisionStrategy
{
    public ColliderFlyweight(collisionGroups c)
    {
        cGroup = c;
    }

    protected void OnEnteredCollision(GameObject c)
    {
        HealthAbstract h = c.GetComponent<HealthAbstract>();

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
        Debug.Log("Disabled: " + gameObject.name + " - " + this.ToString());
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
