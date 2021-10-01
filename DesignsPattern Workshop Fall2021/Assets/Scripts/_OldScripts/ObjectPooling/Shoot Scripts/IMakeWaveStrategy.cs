using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMakeWaveStrategy
{
    public List<GameObject> MakeWave(INeedWaveStrategy waveHolder);
}
