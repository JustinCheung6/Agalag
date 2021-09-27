using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthStrategy
{
    public override void Hurt()
    {
        healthPoints -= 1;

        if (healthPoints <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
