using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyShoot : ObjectPoolingAbstract
{
    /*
    [Header("Bullet Properties")]
    [SerializeField] protected Vector3 spawnOffset = new Vector3(0, 1, 0);
    [SerializeField] protected Sprite bulletSprite = null;

    [Header("Shooting Proprerties")]
    [SerializeField] protected int bulletAmount = 1;
    [Tooltip("Time before each bullet")]
    [SerializeField] protected float bulletSpacing = 1f;

    //Get Object from ObjectPool, and set up properties to be a enemy bullet
    public override GameObject GetObject()
    {
        GameObject pooled = objectPools[poolType].GetObject();

        //Set direction to go up (towards enemies)
        pooled.GetComponent<DirectionalMovement>().SetDirection(DirectionalMovement.Direction.down);
        pooled.GetComponent<SpriteRenderer>().sprite = bulletSprite;
        pooled.transform.position = transform.position + spawnOffset;
        pooled.GetComponent<CollisionAbstract>().CGroup = CollisionAbstract.collisionGroups.Enemy;
        pooled.GetComponent<BoxCollider2D>().size = pooled.GetComponent<SpriteRenderer>().size;
        return pooled;
    }
    */
}
