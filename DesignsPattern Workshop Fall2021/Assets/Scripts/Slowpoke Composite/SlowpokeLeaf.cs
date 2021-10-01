using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowpokeLeaf : MonoBehaviour
{
    private bool startUp = false;

    private SlowpokeClient client = null;
    private SlowpokeComposite composite = null;
    private void OnDisable()
    {
        if (startUp == false)
        {
            startUp = true;
            return;
        }
        if(client != null)
            client.LeafDeath();
        if (composite != null)
            composite.LeafDeath(gameObject);
    }
    public void SetClient(SlowpokeClient client) { this.client = client; }
    public void SetComposite(SlowpokeComposite composite) { this.composite = composite; }
}
