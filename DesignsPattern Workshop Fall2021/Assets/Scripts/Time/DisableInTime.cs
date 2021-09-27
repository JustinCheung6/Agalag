using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableInTime : MonoBehaviour, ITimeEvent
{
    [SerializeField] protected float time = 10f;

    private bool running = false;
    private int interruptions = 0;
    private void OnEnable()
    {
        TimeManager.S.AddTimeEvent(this, time);
    }
    private void OnDisable()
    {
        if (running)
            interruptions += 1;
    }

    public void Activate()
    {
        if (interruptions > 0)
            interruptions--;
        else
        {
            running = false;
            gameObject.SetActive(false);
        }
    }
}
