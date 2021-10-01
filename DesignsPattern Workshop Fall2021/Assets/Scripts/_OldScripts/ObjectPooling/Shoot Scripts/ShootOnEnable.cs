using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootOnEnable// : EnemyShoot, ITimeEvent
{
    /*
    [Tooltip("Time before first bullet")]
    [SerializeField] protected float startDelay = 0f;

    private bool bulletQueued = false;
    private int timesShot = 0;
    private int id = 0;

    protected virtual void OnEnable()
    {
        timesShot = 0;
        if (startDelay > 0f)
            LevelManager.S.AddTimeEvent(this, startDelay, id);
        else
            LevelManager.S.AddTimeEvent(this, 0, id);
        bulletQueued = true;
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

        if(bulletAmount > timesShot)
        {
            bulletQueued = true;
            LevelManager.S.AddTimeEvent(this, bulletSpacing, id);
        }
    }
    */
}
