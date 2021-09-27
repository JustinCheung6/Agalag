using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowpokeComposite : PoolableObjectFlyweight
{
    private List<GameObject> leaves = new List<GameObject>();
    private int leafCount = 0;

    private SlowpokeClientSpawner client = null;
    public SlowpokeClientSpawner Client { set => client = value; }
    protected override void OnDisable()
    {
        leaves = new List<GameObject>();
        leafCount = 0;
        base.OnDisable();
    }
    public void AddLeaf(GameObject leaf)
    {
        leaves.Add(leaf);
        leaf.GetComponent<SlowpokeLeafHealth>().MyComposite = this;
        leafCount++;
    }
    public void RemoveLeaf(GameObject leaf)
    {
        if (leaves.Contains(leaf))
        {
            int i = leaves.IndexOf(leaf);

            leaves[i] = null;
            leafCount--;
            client.RemoveLeaf(i, leaf);
            if (leafCount == 0)
            {
                client.RemoveComposite(this);
                gameObject.SetActive(false);
            }
        }
    }
    public bool HasLeaf(GameObject leaf)
    {
        return leaves.Contains(leaf);
    }
    public bool HasLeaf(int index)
    {
        return leaves[index] != null;
    }
    public GameObject GetLeaf(int index)
    {
        return leaves[index];
    }
}
