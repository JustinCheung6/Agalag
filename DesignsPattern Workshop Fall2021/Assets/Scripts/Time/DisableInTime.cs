using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableInTime : TimeEventStrategy
{
    [SerializeField] protected float time = 10f;

    private bool running = false;
    private int interruptions = 0;
    private void OnEnable()
    {
        Queue(time);
    }
    private void OnDisable()
    {
        if (running)
            interruptions += 1;
    }

    public override void Activate()
    {
        if (interruptions > 0)
            interruptions--;
        else
        {
            running = false;
            gameObject.GetComponent<PoolableObjectFlyweight>().ReturnObject();
        }
    }
}
