using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundariesManager : MonoBehaviour
{
    private List<TriggerTracker> triggers = new List<TriggerTracker>();
    public void AddTrigger(TriggerTracker t) { triggers.Add(t); }
    public void UpdateTriggers(TriggerTracker disabled)
    {
        foreach(TriggerTracker t in triggers)
        {
            if (t != disabled)
                t.gameObject.SetActive(true);
        }
    }
}
