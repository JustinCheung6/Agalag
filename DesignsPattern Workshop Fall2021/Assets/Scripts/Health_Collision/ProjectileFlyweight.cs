using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFlyweight : ColliderAbstract
{
    public override void OnEnteredCollision(GameObject c)
    {
        //Debug.Log(gameObject + " Collided with: " + c);
        HealthStrategy h = c.GetComponent<HealthStrategy>();

        if (h == null)
            return;
        else if (h.AreMatchingCGroups(cGroup) || h.AreMatchingCGroups(collisionGroups.Undecided))
            return;
        else
        {
            h.LoseHealth();
            Destroy();
        }
    }

    public void Destroy()
    {
        Debug.Log(gameObject.name + " was deactivated because of " + name + " script");
        gameObject.SetActive(false);
    }
}
