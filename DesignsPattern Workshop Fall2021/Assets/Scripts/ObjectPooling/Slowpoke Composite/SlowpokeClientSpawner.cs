using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowpokeClientSpawner : ObjectPoolingStrategy, IMakeWaveStrategy
{

    #region List Properties
    private List<SlowpokeComposite> composites = new List<SlowpokeComposite>();
    private List<int> topSlowpoke = new List<int>();
    #endregion

    #region Client Properties
    private Vector3 startPosition = new Vector3();
    private int rows = 8;
    #endregion

    #region Leaf Properties
    [Header("Enemy (Leaf) Properties")]
    [SerializeField] protected Sprite slowpokeSprite = null;
    public Sprite SlowpokeSprite { get => slowpokeSprite; }
    #endregion

    #region Wave Properties
    private List<GameObject> wave = new List<GameObject>();
    private INeedWaveStrategy needsWave = null;
    #endregion

    //Object References
    [SerializeField] private StateMachineFlyweight slowpokeStateMachine = null;
    [SerializeField] private SlowpokeCompositeSpawner compositeSpawner = null;

    //Wave Handling

    private void Awake()
    {
        startPosition = transform.position;
        poolType = PoolType.EnemyPool;

        compositeSpawner.Client = this;
    }

    private void StartLevel()
    {
        transform.position = startPosition;
        topSlowpoke = new List<int>();

        for (int row = 0; row < rows; row++)
        {
            SlowpokeComposite composite = compositeSpawner.GetObject().GetComponent<SlowpokeComposite>();
            composite.transform.SetParent(transform);
            composite.transform.localPosition = new Vector3(0f, row * 1.5f, 0f);

            composites.Add(composite);
            if(topSlowpoke.Count < 8)
                topSlowpoke.Add(0);
        }
        MakeWave();

        slowpokeStateMachine.enabled = true;
    }

    //Get Leaf Object from ObjectPool
    public override GameObject GetObject()
    {
        GameObject pooled = objectPools[poolType].GetObject();

        pooled.GetComponent<SpriteRenderer>().sprite = SlowpokeSprite;

        //Setup different components for a slowpoke enemy
        pooled.GetComponent<DirectionalMovement>().SetDirection(DirectionalMovement.Direction.down);

        return pooled;
    }

    public void RemoveLeaf(int column, GameObject leaf)
    {
        if (wave.Contains(leaf))
            wave.Remove(leaf);
        if (GetTopsSlowpoke(column) != null)
            wave.Add(GetTopsSlowpoke(column));
    }
    public void RemoveComposite(SlowpokeComposite c)
    {
        int cIndex = composites.IndexOf(c);
        composites.Remove(c);

        if(composites.Count == 0)
        {
            slowpokeStateMachine.enabled = false;
        }
        else
        {
            for (int i = 0; i < topSlowpoke.Count; i++)
            {
                if (topSlowpoke[i] == cIndex)
                    GetTopsSlowpoke(i);
                else if (topSlowpoke[i] > cIndex)
                    topSlowpoke[i]--;
            }
        }
    }
    public void MakeWave()
    {
        for (int i = 0; i < topSlowpoke.Count; i++)
        {
            if (GetTopsSlowpoke(i) != null)
                wave.Add(GetTopsSlowpoke(i));
        }
    }
    public List<GameObject> MakeWave(INeedWaveStrategy waveHolder)
    {
        needsWave = waveHolder;
        if (wave.Count == 0)
            MakeWave();

        return wave;
    }
    public GameObject GetTopsSlowpoke(int column)
    {
        if (topSlowpoke[column] == rows)
            return null;

        for(int r = topSlowpoke[column]; r < rows; r++)
            if (composites[r].HasLeaf(column))
            {
                topSlowpoke[column] = r;
                return composites[r].GetLeaf(column);
            }

        topSlowpoke[column] = rows;
        return null;
    }
}
