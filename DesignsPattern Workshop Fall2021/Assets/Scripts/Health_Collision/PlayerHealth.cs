using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthStrategy
{
    protected override void OnEnable()
    {
        base.OnEnable();
        LevelManager.LevelStartedEvent += LevelClear;
    }
    public override void LoseHealth()
    {
        base.LoseHealth();
        LevelManager.S.SetHealthDisplay(healthPoints);
    }
    protected override void Death()
    {
        MenuManager.S.GameOver();
    }
    private void LevelClear()
    {
        if (healthPoints < maxHealth)
        {
            healthPoints++;
            LevelManager.S.SetHealthDisplay(healthPoints);
        }
    }
}
