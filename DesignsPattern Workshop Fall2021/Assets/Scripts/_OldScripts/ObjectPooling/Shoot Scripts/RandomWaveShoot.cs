using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWaveShoot// : ShootOnEnable, INeedWaveStrategy
{
    /*
    [SerializeField] SlowpokeClient waveSource = null;

    private List<GameObject> wave = null;
    private int lastWaveShot = -1;

    private void Awake()
    {
        wave = waveSource.MakeWave(this);
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        lastWaveShot = -1;
    }

    public void SendWave(List<GameObject> wave)
    {
        this.wave = wave;
    }

    public override GameObject GetObject()
    {
        GameObject pooled = base.GetObject();
        pooled.transform.position = GetRandomFromWave().transform.position + spawnOffset;
        pooled.SetActive(true);

        return pooled;
    }

    public GameObject GetRandomFromWave()
    {
        //Chooses random gameObject from list (avoids one chosen last)
        int index = Random.Range(0, wave.Count - ((lastWaveShot == -1) ? 1 : 2) );
        if (index >= lastWaveShot)
            index++;

        lastWaveShot = index;
        return wave[index];
    }
    */
}
