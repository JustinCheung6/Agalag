using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableObjectFlyweight : ObjectPoolingAbstract, ITimeEvent
{
    //Move object transforms (nextFrame)
    private static List<PoolableObjectFlyweight> returningObjects = new List<PoolableObjectFlyweight>();
    private static List<Transform> transformChecker = new List<Transform>();
    private static bool returning = false;

    protected void Awake()
    {
        returningObjects = new List<PoolableObjectFlyweight>();
        transformChecker = new List<Transform>();
        returning = false;
    }
    protected virtual void OnDisable()
    {
        returningObjects.Add(this);
        transformChecker.Add(transform.parent);
        if (!returning)
        {
            returning = true;
            if(TimeManager.S != null)
                TimeManager.S.AddTimeEvent(this, 0f);
        }
    }
    //Return objects to pool
    public void Activate(int id)
    {
        while(returningObjects.Count > 0)
        {
            objectPools[returningObjects[0].poolType].AddToPool(returningObjects[0].gameObject);
            if (transform.parent == transformChecker[0])
                returningObjects[0].transform.SetParent(objectPools[returningObjects[0].poolType].transform);
            returningObjects.RemoveAt(0);
            transformChecker.RemoveAt(0);
        }
        returning = false;
    }
}
