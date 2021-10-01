using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTracker : CollisionBase
{
    /*
    [SerializeField] private int triggersNeeded = 1;
    private int triggerCounter = 0;

    private BoundariesManager parent = null;
    private void Awake()
    {
        if(transform.parent != null)
        {
            parent = transform.GetComponentInParent<BoundariesManager>();
            parent.AddTrigger(this);
        }
    }
    private void OnDisable()
    {
        triggerCounter = 0;
        parent.UpdateTriggers(this);
    }
    protected void OnEnteredCollision(GameObject c)
    {
        IReactToTrigger r = c.GetComponent<IReactToTrigger>();
        if (r == null)
            return;
        CollisionAbstract t = c.GetComponent<CollisionAbstract>();
        

        if (t == null)
            return;
        else if (t.CGroup == cGroup)
        {
            triggerCounter++;
            r.React(this);
            if (triggerCounter >= triggersNeeded)
                gameObject.SetActive(false);
        }
            
    }

    protected void OnTriggerEnter2D(Collider2D c)
    {
        OnEnteredCollision(c.gameObject);
    }
    protected void OnCollisionEnter2D(Collision2D c)
    {
        OnEnteredCollision(c.gameObject);
    }
    */
}
