using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableObjectFlyweight : ObjectPoolingStrategy
{
    protected virtual void OnDisable()
    {
        StartCoroutine(Buffer());
    }
    public void SetupPoolableObject(PoolType p)
    {
        poolType = p;
        gameObject.SetActive(false);

    }

    public override GameObject GetObject()
    {
        if (gameObject.activeSelf)
            return null;

        transform.SetParent(null);
        objectPools[poolType].RemoveFromList(this);
        return this.gameObject;
    }

    private IEnumerator Buffer()
    {
        yield return new WaitForEndOfFrame();
        ReturnObject();
    }
    protected virtual void ReturnObject()
    {
        transform.SetParent(objectPools[poolType].transform);
    }
}
