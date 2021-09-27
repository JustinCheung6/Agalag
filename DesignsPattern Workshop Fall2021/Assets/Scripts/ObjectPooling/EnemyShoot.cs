using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyShoot : ObjectPoolingStrategy
{
    //Bullet Properties
    protected Vector3 spawnOffset = new Vector3(0, 1, 0);
    public Vector3 SpawnOffset { set => spawnOffset = value; }
    protected Sprite bulletSprite = null;
    public Sprite BulletSprite { set => bulletSprite = value; }
    //Shooting Properties
    protected int bulletAmount = 1;
    public int BulletAmount { set => bulletAmount = value; }
    protected float bulletSpacing = 1f;
    public float BulletSpacing { set => bulletSpacing = value; }

    //Get Object from ObjectPool, and set up properties to be a enemy bullet
    public override GameObject GetObject()
    {
        GameObject pooled = objectPools[poolType].GetObject();

        //Set direction to go up (towards enemies)
        pooled.GetComponent<DirectionalMovement>().SetDirection(DirectionalMovement.Direction.down);
        pooled.GetComponent<SpriteRenderer>().sprite = bulletSprite;
        pooled.transform.position = transform.position + spawnOffset;

        pooled.SetActive(true);
        return pooled;
    }
}
