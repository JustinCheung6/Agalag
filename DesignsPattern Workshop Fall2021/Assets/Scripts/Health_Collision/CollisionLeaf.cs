using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLeaf : ColliderAbstract
{
    [Header("Debugging")]
    [SerializeField] ColliderAbstract parentCollider = null;
    private void GetParentCollider()
    {
        Transform p = transform.parent;

        while (p != null)
        {
            ColliderAbstract[] parentColliders = p.GetComponents<ColliderAbstract>();
            foreach (ColliderAbstract c in parentColliders)
            {
                if (c.CGroup != cGroup)
                    continue;
                parentCollider = c;
                return;
            }
            p = p.transform.parent;
        }
    }

    public override void OnEnteredCollision(GameObject c)
    {
        if (parentCollider == null)
            GetParentCollider();
        if (parentCollider != null)
            parentCollider.OnEnteredCollision(c);
    }
}
