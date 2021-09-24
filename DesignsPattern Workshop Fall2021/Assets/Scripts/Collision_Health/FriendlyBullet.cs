using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyBullet : ColliderAbstract
{
    private void Awake()
    {
        cGroup = collisionGroups.Player;
    }

    protected override void OnEnteredCollision(GameObject c)
    {
        HealthAbstract h = c.GetComponent<HealthAbstract>();

        if (h == null)
            return;

        if (h.cGroup == collisionGroups.Undecided)
            return;

        if(h.cGroup == this.cGroup)
        {
            h.Hurt();
        }
    }
}
