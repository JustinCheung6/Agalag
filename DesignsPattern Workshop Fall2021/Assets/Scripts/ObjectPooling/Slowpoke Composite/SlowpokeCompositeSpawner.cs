using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowpokeCompositeSpawner : ObjectPoolingStrategy
{
    private SlowpokeClientSpawner client = null;
    public SlowpokeClientSpawner Client { set => client = value; }

    public override GameObject GetObject()
    {
        GameObject composite = objectPools[poolType].GetObject();

        float startX = transform.position.x - (0.5f + 4.5f);

        //Setup leaves in composite 
        for (int column = 0; column < 8; column++)
        {
            GameObject leaf = client.GetObject();
            leaf.transform.position = new Vector3(startX + (column * 1.5f), transform.position.y, transform.position.z);
            leaf.transform.parent = composite.transform;

            composite.GetComponent<SlowpokeComposite>().AddLeaf(leaf);
        }

        return composite;
    }
}
