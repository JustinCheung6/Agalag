using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableObjectFlyweight : ObjectPoolingStrategy
{

    public void SetupPoolableObject(PoolType p)
    {
        poolType = p;
        ReturnObject();

    }

    public override GameObject GetObject()
    {
        if (gameObject.activeSelf)
            return null;

        transform.parent = null;
        objectPools[poolType].RemoveFromList(this);
        return this.gameObject;
    }
    public void ReturnObject()
    {
        transform.parent = objectPools[poolType].transform;
        gameObject.SetActive(false);
    }
}
