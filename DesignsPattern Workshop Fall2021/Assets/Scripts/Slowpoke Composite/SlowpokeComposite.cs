using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowpokeComposite : ObjectPoolingAbstract
{
    private SlowpokeClient client = null;

    [SerializeField] private List<GameObject> leaves = new List<GameObject>();

    public int CreateLeaves(int amount, float spacing)
    {
        int created = 0;
        for (int i = 0; i < amount; i++)
        {
            created++;
            GameObject leaf = objectPools[poolType].GetObject(transform);
            leaf.transform.localPosition = new Vector3(0f, i * spacing, 0f);
            leaf.transform.SetParent(transform);
            leaf.GetComponent<SlowpokeLeaf>().SetComposite(this);
            leaf.GetComponent<SlowpokeLeaf>().SetClient(client);
            leaves.Add(leaf);
        }
        return created;
    }
    public GameObject GetFrontLeaf()
    {
        for(int i = 0; i < leaves.Count; i++)
        {
            if (leaves[i].activeSelf)
                return leaves[i];
        }
        return null;
    }
    public void LeafDeath(GameObject leaf)
    {
        leaves.Remove(leaf);
    }
    public void SetClient(SlowpokeClient client) { this.client = client; }
}
