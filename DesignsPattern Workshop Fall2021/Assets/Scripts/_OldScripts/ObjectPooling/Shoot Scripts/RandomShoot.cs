using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomShoot// : EnemyShoot, ITimeEvent
{
    /*
    [Tooltip("Time span where bullet could be shot")]
    [SerializeField] private float timeSpan;

    private bool bulletQueued = false;
    private int timesShot = 0;
    private int id = 0;

    protected virtual void OnEnable()
    {
        

        
    }
    protected virtual void OnDisable()
    {
        if (bulletQueued)
            id++;
        else
            id = 0;
    }
    public void Activate(int id)
    {
        if (this.id != id)
            return;

        bulletQueued = false;
        timesShot++;

        GetObject().SetActive(true);

        if (bulletAmount > timesShot)
        {
            bulletQueued = true;
            QueueBullet();
        }
    }

    public void QueueBullet()
    {
        float randomTime = Random.Range(bulletSpacing * 0.5f, bulletSpacing * 0.5f + timeSpan);
        LevelManager.S.AddTimeEvent(this, randomTime, id);
        bulletQueued = true;
    }
    */
}
