using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : ObjectPoolFlyweight
{
    private static BulletFactory s = null;
    public static BulletFactory S { get => s; }

    [SerializeField] private List<GameObject> bulletPrefabs;

    private Dictionary<CollisionBase.collisionGroups, GameObject> bulletReferences = 
        new Dictionary<CollisionBase.collisionGroups, GameObject>();

    protected override void Awake()
    {
        if (s == null)
            s = this;

        base.Awake();
        //Create a reference for each bullet
        foreach(GameObject prefab in bulletPrefabs)
        {
            CollisionBase o = Instantiate(prefab, transform).GetComponent<CollisionBase>();
            bulletReferences.Add(o.CGroup, o.gameObject);
        }
    }
    private void OnEnable()
    {
        if (s == null)
            s = this;
    }
    private void OnDisable()
    {
        if (s == this)
            s = null;
    }

    public GameObject CreateBullet(CollisionBase.collisionGroups c, Vector3 origin)
    {
        GameObject bullet = GetObject();
        GameObject reference = bulletReferences[c];

        bullet.GetComponent<SpriteRenderer>().sprite = reference.GetComponent<SpriteRenderer>().sprite;
        bullet.GetComponent<BoxCollider2D>().size = reference.GetComponent<BoxCollider2D>().size;
        bullet.GetComponent<DirectionalMovement>().SetSpeed(reference.GetComponent<DirectionalMovement>().Speed);
        bullet.GetComponent<DirectionalMovement>().SetDirection(reference.GetComponent<DirectionalMovement>().GetDirection());
        bullet.GetComponent<CollisionBase>().SetCGroup(reference.GetComponent<CollisionBase>().CGroup);

        bullet.transform.position = origin;

        return bullet;
    }
}
