using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthAbstract
{
    public override void Hurt()
    {
        healthPoints -= 1;

        if(healthPoints <= 0)
        {
            MenuManager.s.GameOver();
        }
    }
}
