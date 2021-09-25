using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolFlyweight : ObjectPoolingStrategy
{
    protected List<PoolableObjectFlyweight> pooledObjects = new List<PoolableObjectFlyweight>();


    [SerializeField] protected GameObject objectPrefab = null;
    [SerializeField] protected int poolSize = 30;

    //Debug
    private int extraObjects = 0;

    private void Awake()
    {
        if (!objectPools.ContainsKey(poolType))
            objectPools.Add(poolType, this);
    }
    private void Start()
    {
        SetupObjectPool();
    }
    private void OnApplicationQuit()
    {
        Debug.Log(gameObject.name + ": " + extraObjects + " objects were added to the object pool");
    }

    public bool RemoveFromList(PoolableObjectFlyweight p)
    {
        return pooledObjects.Remove(p);
    }

    protected virtual void SetupObjectPool()
    {
        for(int i = 0; i < poolSize; i++)
        {
            PoolableObjectFlyweight newObject = AddObject().GetComponent<PoolableObjectFlyweight>();

            pooledObjects.Add(newObject);
        }
    }

    protected virtual GameObject AddObject()
    {
        GameObject newObject = Instantiate(objectPrefab);
        newObject.GetComponent<PoolableObjectFlyweight>().SetupPoolableObject(poolType);

        return newObject;
    }
    //Gets and returns an object from the pool by calling the poolableObject's GetObject
    public override GameObject GetObject()
    {
        if (pooledObjects.Count == 0)
        {
            extraObjects++;
            return AddObject();
        }
        else
            return pooledObjects[0].GetObject();
    }
}
