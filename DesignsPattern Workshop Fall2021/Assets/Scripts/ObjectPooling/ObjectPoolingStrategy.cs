using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPoolingStrategy : MonoBehaviour
{
    public enum PoolType
    {
        Undecided = 0,
        BulletPool = 1
    };

    [SerializeField] protected PoolType poolType;

    protected static Dictionary<PoolType, ObjectPoolFlyweight> objectPools =
    new Dictionary<PoolType, ObjectPoolFlyweight>();

    
    public abstract GameObject GetObject();
}
