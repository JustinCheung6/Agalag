using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private static TimeManager s = null;
    public static TimeManager S { get => s; }
    //Time Manager Properties
    private List<System.Tuple<ITimeEvent, float, int>> timeEvents = new List<System.Tuple<ITimeEvent, float, int>>();
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

    private void FixedUpdate()
    {
        if (timeEvents.Count == 0)
            return;

        while (Time.fixedTime >= timeEvents[0].Item2)
        {
            timeEvents[0].Item1.Activate(timeEvents[0].Item3);
            timeEvents.RemoveAt(0);

            if (timeEvents.Count == 0)
                return;
        }
    }
    
    public void AddTimeEvent(ITimeEvent timeEvent, float time, int id = 0)
    {
        System.Tuple<ITimeEvent, float, int> tuple = new System.Tuple<ITimeEvent, float, int>(timeEvent, Time.fixedTime + time, id);

        if(timeEvents.Count == 0)
        {
            timeEvents.Add(tuple);
            return;
        }
        else if (timeEvents[timeEvents.Count - 1].Item2 <= tuple.Item2)
        {
            timeEvents.Add(tuple);
            return;
        }

        for (int i = 0; i < timeEvents.Count; i++)
            if (timeEvents[i].Item2 > tuple.Item2)
                {
                    timeEvents.Insert(i, tuple);
                    return;
                }
        
        timeEvents.Insert(timeEvents.Count, tuple);
    }
}
