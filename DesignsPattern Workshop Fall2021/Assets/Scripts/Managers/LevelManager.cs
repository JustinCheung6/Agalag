using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour, ITimeEvent
{
    private static LevelManager s = null;
    public static LevelManager S { get => s; }
    public enum LevelState
    {
        startLevel,
        running,
        endLevel
    }
    private LevelState levelState = LevelState.startLevel;
    public delegate void StartLevelDelegate();
    public static StartLevelDelegate LevelStartedEvent;

    //Level Manager Properties
    private int level = 0;
    private int Level
    {
        get => level;
        set
        {
            level = value;
            UpdateScore();
            SetLevelDisplay();
        }
    }
    private int enemiesKilled = 0;
    private int EnemiesKilled 
    {
        get => enemiesKilled;
        set
        {
            enemiesKilled = value;
            UpdateScore();
        } 
    }
    private int enemiesAlive = 0;

    [SerializeField] private int enemyScoreValue = 1;
    [SerializeField] private int levelScoreValue = 100;

    private float endLevelDuration = 10f;
    public float EndLevelDuration { get => endLevelDuration; }

    //End Level Assets
    [SerializeField] private GameObject levelUI = null;
    [SerializeField] private GameObject levelCompleteUI = null;

    //UI Details
    [SerializeField] private List<GameObject> healthIndicators = new List<GameObject>();
    [SerializeField] private Text levelDisplay = null;
    [SerializeField] private Text scoreDisplay = null;
    private void OnEnable()
    {
        if (s == null)
            s = this;        
    }
    private void Start()
    {
        level = 1;
        UpdateScore();
        SetLevelDisplay();
        StartLevel();
    }
    private void StartLevel()
    {
        enemiesAlive = 0;
        levelState = LevelState.startLevel;
        if (LevelStartedEvent != null)
        {
            Debug.Log("Delegate Event");
            LevelStartedEvent.Invoke();
        }
        levelState = LevelState.running;
    }
    private void EndLevel()
    {
        levelState = LevelState.endLevel;
        if(levelUI != null)
            levelUI.SetActive(false);
        if(levelCompleteUI != null)
            levelCompleteUI.SetActive(true);
        TimeManager.S.AddTimeEvent(this, endLevelDuration);
    }
    public void EnemyCreated()
    {
        enemiesAlive++;
    }
    public void EnemyDestroyed()
    {
        enemiesAlive--;
        EnemiesKilled++;
        if (enemiesAlive <= 0 && levelState == LevelState.running)
            EndLevel();
        else if(enemiesAlive <= 0)
            Debug.Log("Level Couldn't End");
    }
    public void Activate(int id)
    {
        if(levelUI != null)
            levelUI.SetActive(true);
        if(levelCompleteUI != null)
            levelCompleteUI.SetActive(false);
        Level++;
        StartLevel();
    }
    public int GetLevel() { return level; }
    public void SetHealthDisplay(int health)
    {
        for (int h = 0; h < 3; h++)
        {
            if(h < health)
                healthIndicators[h].SetActive(true);
            else
                healthIndicators[h].SetActive(false);
        }   

    }
    public int UpdateScore()
    {
        int score = enemiesKilled * enemyScoreValue + (level - 1) * levelScoreValue;
        scoreDisplay.text = "Score: " + score;
        return score;
    }
    public void SetLevelDisplay()
    {
        levelDisplay.text = "Level: " + level;
    }
}
