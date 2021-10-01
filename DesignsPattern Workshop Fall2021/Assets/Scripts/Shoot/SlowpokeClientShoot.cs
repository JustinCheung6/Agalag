using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowpokeClientShoot : MonoBehaviour, ITimeEvent
{
    [SerializeField] private SlowpokeClient client = null;
    [Tooltip("Minimum time between bullets")]
    [SerializeField] private float minfireRate = 3f;
    [Tooltip("Minimum time between bullets")]
    [SerializeField] private float maxfireRate = 6f;
    private int lastIndex = -1;
    private int missingEnemies;
    private int id = 0;
    private void OnEnable()
    {
        TimeManager.S.AddTimeEvent(this, Random.Range(minfireRate, maxfireRate) + (missingEnemies / 3), id);
    }
    private void OnDisable()
    {
        id = (id >= 99) ? 0 : id + 1;
    }
    private void Shoot()
    {
        BulletFactory.S.CreateBullet(CollisionBase.collisionGroups.Enemy, GetRandomPosition());
        TimeManager.S.AddTimeEvent(this, Random.Range(minfireRate, maxfireRate), id);
    }
    public Vector3 GetRandomPosition()
    {
        List<Vector3> positions = new List<Vector3>();
        List<int> positionIndices = new List<int>();
        Vector3 backupLeafPos = new Vector3();

        for (int i = 0; i < client.Columns; i++)
        {
            if (i == lastIndex)
            {
                if(client.GetComposite(i).GetFrontLeaf() != null)
                    backupLeafPos = client.GetComposite(i).GetFrontLeaf().transform.position;
                continue;
            }

            GameObject leaf = client.GetComposite(i).GetFrontLeaf();

            if (leaf != null)
            {
                positions.Add(leaf.transform.position);
                positionIndices.Add(i);
            }
                
        }
        if (positions.Count == 0)
            return backupLeafPos;

        int r = Random.Range(0, positions.Count);
        lastIndex = positionIndices[r];
        missingEnemies = client.Columns - positions.Count;
        return positions[r];
    }

    public void Activate(int id)
    {
        if (this.id != id)
            return;
        Shoot();
    }
}
