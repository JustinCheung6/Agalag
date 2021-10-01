using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolFlyweight : ObjectPoolingAbstract, ITimeEvent
{
    protected List<GameObject> objectPool = new List<GameObject>();

    //Setting objects active (nextframe)
    private static List<GameObject> pooledObjects = new List<GameObject>();
    private static bool pooling = false;

    [SerializeField] protected GameObject objectPrefab = null;
    [SerializeField] protected int poolSize = 30;

    //Debug
    private int extraObjects = 0;
    protected virtual void Awake()
    {
        ClearPool();
        pooling = false;
        if (objectPools.ContainsKey(poolType))
            objectPools.Remove(poolType);
        objectPools.Add(poolType, this);

        SetupObjectPool();
    }
    private void OnApplicationQuit()
    {
        if(extraObjects > 0)
            Debug.Log(gameObject.name + ": " + extraObjects + " objects were added to the object pool");
    }
    public void AddToPool(GameObject p) 
    {
        if (objectPool.Contains(p))
            return;
        objectPool.Add(p); 
    }
    protected void SetupObjectPool()
    {
        for(int i = 0; i < poolSize; i++)
        {
            GameObject newObject = GetNewObject();

            objectPool.Add(newObject);
            newObject.SetActive(false);
            newObject.transform.SetParent(transform);
        }
    }
    //Gets and returns an object from the pool by calling the poolableObject's GetObject
    public GameObject GetObject(Transform parent = null)
    {
        GameObject pooled = null;

        //Get Object from pool or make a new one if empty
        if (objectPool.Count == 0)
        {
            Debug.Log("Making New");
            extraObjects++;
            pooled = GetNewObject();
        }
        else
        {
            pooled = objectPool[0];
            objectPool.RemoveAt(0);
        }
        //Setup properties of pool
        pooled.transform.SetParent(parent);
        pooledObjects.Add(pooled);
        if (!pooling)
        {
            TimeManager.S.AddTimeEvent(this, 0f);
            pooling = true;
        }

        return pooled;
    }
    protected GameObject GetNewObject()
    {
        return Instantiate(objectPrefab);
    }
    //Activate all the objects pooled at the next frame (because you can't activate object at the same frame as setting parents)
    public void Activate(int id)
    {
        while(pooledObjects.Count > 0)
        {
            pooledObjects[0].SetActive(true);
            pooledObjects.RemoveAt(0);
        }
        pooling = false;
    }
    private void ClearPool()
    {
        while (objectPool.Count > 0)
        {
            Destroy(objectPool[0]);
            objectPool.RemoveAt(0);
        }
    }
}
