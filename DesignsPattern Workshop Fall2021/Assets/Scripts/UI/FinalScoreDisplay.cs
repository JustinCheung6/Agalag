using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreDisplay : MonoBehaviour
{
    [SerializeField]private Text display = null;

    private void OnEnable()
    {
        display.text = "Final Score: " + LevelManager.S.UpdateScore();
    }
}
