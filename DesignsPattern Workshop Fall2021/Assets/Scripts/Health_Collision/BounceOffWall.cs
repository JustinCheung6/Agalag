using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOffWall : ColliderAbstract
{
    [SerializeField] private DirectionalMovement moveScript = null;
    [SerializeField] private GameObject lastCollider = null;
    public override void OnEnteredCollision(GameObject c)
    {
        CollisionBase collider = c.GetComponent<CollisionBase>();
        if (collider == null)
            return;
        else if (!collider.AreMatchingCGroups(cGroup) || lastCollider == c)
            return;
        else
        {
            moveScript.SwapDirection();
            lastCollider = c;
            if(OnCollide != null)
                OnCollide();
        }
    }
}
