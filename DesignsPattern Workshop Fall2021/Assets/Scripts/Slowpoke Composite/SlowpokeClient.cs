using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowpokeClient : MonoBehaviour
{
    [SerializeField] GameObject compositePrefab = null;
    [SerializeField] private int startColumns = 4;
    [SerializeField] private int startRows = 4;
    [SerializeField] private float spacing = 1.5f;

    private int columns = 0;
    public int Columns { get => columns; }
    private int rows = 0;

    private List<SlowpokeComposite> composites = new List<SlowpokeComposite>();
    private int leafCount = 0;

    [SerializeField] private SlowpokeClientStateMachine stateMachine = null;

    [SerializeField] private bool debug = false;

    private void OnEnable()
    {
        LevelManager.LevelStartedEvent += StartLevel;
    }
    private void Start()
    {
        if (debug)
        {
            Debug.Log("Debugging: " + this.name);
            StartLevel();
        }
    }
    private void CreateWaves()
    {
        leafCount = 0;
        float startingX = (columns % 2 == 0 ? -spacing / 2f : 0f) - ((columns - 1) / 2 * spacing);

        //Update Composites that have already been made
        for(int c = 0; c < composites.Count; c++)
        {
            leafCount += composites[c].CreateLeaves(rows, spacing);
            composites[c].transform.localPosition = new Vector3(startingX + spacing * c, 0f, 0f);
        }
        for (int c = composites.Count; c < columns; c++)
        {

            composites.Add(Instantiate(compositePrefab, transform).GetComponent<SlowpokeComposite>());
            composites[c].SetClient(this);
            composites[c].transform.localPosition = new Vector3(startingX + spacing * c, 0f, 0f);
            leafCount += composites[c].CreateLeaves(rows, spacing);
        }
    }
    private void StartLevel()
    {
        Debug.Log("Enemies started");
        int newLevels = LevelManager.S.GetLevel() - 1;
        rows = Mathf.Clamp(startRows + newLevels - newLevels / 4, 1, 8);
        if (rows <= 8)
            columns = startColumns + newLevels / 4;
        else
            columns = Mathf.Clamp(startColumns + newLevels - (8 - startRows) / 4 * 3, 1, 20);
        transform.position = new Vector3(0f, 9f - spacing * (rows - 1), 0f);

        CreateWaves();
        stateMachine.enabled = true;
    }
    private void Deactivate()
    {
        stateMachine.enabled = false;
    }
    public SlowpokeComposite GetComposite(int column)
    {
        return composites[column];
    }
    public void LeafDeath()
    {
        leafCount--;
        if (leafCount == 0)
            Deactivate();
    }
}
