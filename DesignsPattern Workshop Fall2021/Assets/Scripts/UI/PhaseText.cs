using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseText : MonoBehaviour, ITimeEvent
{
    [SerializeField] Text text = null;
    [SerializeField] private int direction = 1;

    private void OnEnable()
    {
        direction = 1;
        TimeManager.S.AddTimeEvent(this, LevelManager.S.EndLevelDuration - 2);
        
    }
    private void Update()
    {
        Color c = text.color;
        c.a = Mathf.Clamp(c.a + direction * Time.deltaTime, 0f, 1f);
        text.color = c;
    }

    public void Activate(int id)
    {
        direction = -1;
    }
}
