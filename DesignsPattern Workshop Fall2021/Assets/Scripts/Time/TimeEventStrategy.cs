using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TimeEventStrategy : MonoBehaviour
{
    public abstract void Activate();

    protected virtual void Queue(float time)
    {
        TimeManager.S.AddTimeEvent(this, time);
    }
}
