using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthStrategy
{
    protected override void OnEnable()
    {
        base.OnEnable();
        healthPoints = maxHealth;
        if (LevelManager.S != null)
            LevelManager.S.EnemyCreated();
    }
    protected override void Death()
    {
        Debug.Log(gameObject.name + " was deactivated because of " + name + " script");
        if (LevelManager.S != null)
            LevelManager.S.EnemyDestroyed();
        gameObject.SetActive(false);
    }
}
