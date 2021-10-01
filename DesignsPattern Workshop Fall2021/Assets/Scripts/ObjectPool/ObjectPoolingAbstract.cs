using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPoolingAbstract : MonoBehaviour
{
    public enum PoolType
    {
        Undecided,
        BulletPool,
        SlowpokePool
    };
    protected static Dictionary<PoolType, ObjectPoolFlyweight> objectPools =
    new Dictionary<PoolType, ObjectPoolFlyweight>();
    public static ObjectPoolFlyweight GetPool(PoolType p) { return objectPools[p]; }

    [SerializeField] protected PoolType poolType;
}
