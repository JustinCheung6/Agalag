using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthStrategy : CollisionBase
{
    [SerializeField] protected int healthPoints;
    protected int maxHealth = 0;
    private void Awake()
    {
        maxHealth = healthPoints;
    }
    public virtual void LoseHealth()
    {
        healthPoints--;
        if (healthPoints == 0)
        {
            Death();
        }
    }
    protected abstract void Death();

}
