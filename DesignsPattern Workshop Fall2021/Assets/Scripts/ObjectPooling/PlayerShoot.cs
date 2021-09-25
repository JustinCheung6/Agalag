using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : ObjectPoolingStrategy
{
    [Header("Bullet Properties")]
    [SerializeField] private Vector3 spawnOffset = new Vector3(0, 1, 0);
    [SerializeField] private Sprite bulletSprite = null;

    private void Update()
    {
        if (Input.GetButtonDown("Fire"))
        {
            GetObject();
        }
    }

    //Get Object from ObjectPool, and set up properties to be a playerbullet
    public override GameObject GetObject()
    {
        GameObject pooled = objectPools[poolType].GetObject();

        //Set direction to go up (towards enemies)
        pooled.GetComponent<DirectionalMovement>().SetDirection(DirectionalMovement.Direction.up);
        pooled.GetComponent<SpriteRenderer>().sprite = bulletSprite;
        pooled.transform.position = transform.position + spawnOffset;

        pooled.SetActive(true);
        return pooled;
    }
}
