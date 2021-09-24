using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager s;

    [SerializeField] private GameObject pauseMenu = null;
    [SerializeField] private GameObject loseMenu = null;

    // 0 = unpaused, 1 = paused, 2 = gameOver
    private int pauseState = 0;

    private void OnEnable()
    {
        if (s == null)
            s = this;
        else
            Debug.Log("Error: Multiple Menu Managers found");

        Time.timeScale = 1;
    }
    private void OnDisable()
    {
        if (s == this)
            s = null;

        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetButtonDown("PauseGame") && pauseState < 2)
        {
            if (pauseState == 0)
                PauseGame();
            else if (pauseState == 1)
                ResumeGame();
        }
    }

    #region Change Menu
    public void GameOver()
    {
        pauseState = 2;
        Time.timeScale = 0;

        pauseMenu.SetActive(false);
        loseMenu.SetActive(true);
    }
    public void PauseGame()
    {
        pauseState = 1;
        Time.timeScale = 0;

        pauseMenu.SetActive(true);
        loseMenu.SetActive(false);
    }
    public void ResumeGame()
    {
        pauseState = 0;
        Time.timeScale = 1;

        pauseMenu.SetActive(false);
        loseMenu.SetActive(false);
    }
    #endregion

    #region Menu Buttons
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ToTitleScreen()
    {
        SceneManager.LoadScene(0);
    }
    #endregion
}
