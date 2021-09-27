using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private static TimeManager s = null;

    private List<System.Tuple<ITimeEvent, float>> timeEvents = new List<System.Tuple<ITimeEvent, float>>();

    private void Awake()
    {
        if (s == null)
            s = this;
        else if(s != this)
            Destroy(this);
    }
    private void OnDisable()
    {
        if(s == this)
            s = null;
    }

    private void Update()
    {
        if (timeEvents.Count == 0)
            return;

        while (Time.time >= timeEvents[0].Item2)
        {
            timeEvents[0].Item1.Activate();
            timeEvents.RemoveAt(0);

            if (timeEvents.Count == 0)
                return;
        }
    }
    public static TimeManager S
    {
        get
        {
            if(s == null)
            {
                GameObject tmp = Instantiate(new GameObject());
                tmp.name = "Time Manager";
                return tmp.AddComponent(typeof(TimeManager)) as TimeManager;
            }
            return s;
        }
    }

    public void AddTimeEvent(ITimeEvent timeEvent, float time)
    {
        System.Tuple<ITimeEvent, float> tuple = new System.Tuple<ITimeEvent, float>(timeEvent, Time.time + time);

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
            if (timeEvents[0].Item2 > tuple.Item2)
                {
                    timeEvents.Insert(i, tuple);
                    return;
                }
    }
}
