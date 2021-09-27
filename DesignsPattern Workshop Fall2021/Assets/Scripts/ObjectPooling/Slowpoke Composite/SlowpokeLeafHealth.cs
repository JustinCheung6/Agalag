using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowpokeLeafHealth : EnemyHealth
{
    private SlowpokeComposite myComposite = null;
    public SlowpokeComposite MyComposite { set => myComposite = value; }
    private void OnDisable()
    {
        myComposite.RemoveLeaf(gameObject);
        myComposite = null;
    }
}
