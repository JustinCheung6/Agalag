using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerReactor : MonoBehaviour, IReactToTrigger
{
    public void React(TriggerTracker source)
    {
        gameObject.SetActive(false);
    }
}
