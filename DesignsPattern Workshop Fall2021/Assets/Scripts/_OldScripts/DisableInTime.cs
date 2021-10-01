using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableInTime : MonoBehaviour, ITimeEvent
{
    [SerializeField] protected float time = 10f;

    private bool running = false;
    [SerializeField] private int id = 0;
    private void OnEnable()
    {
        TimeManager.S.AddTimeEvent(this, time, id);
        running = true;
    }
    private void OnDisable()
    {
        if (running)
            id += 1;
        else
            id = 0;
    }

    public void Activate(int id)
    {
        if (this.id == id)
        {
            running = false;
            gameObject.SetActive(false);
        }
        else
        {
            //Debug.Log("Activate Fail " + gameObject.name);
        }
    }
}
