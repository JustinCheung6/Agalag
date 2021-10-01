using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INeedWaveStrategy 
{
    public void SendWave(List<GameObject> wave);
}
