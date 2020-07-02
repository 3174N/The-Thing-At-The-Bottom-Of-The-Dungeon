using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    #region variables
    public GameObject pauseMenu;
    public GameObject[] canvases;

    bool isPaused;

    LevelLoader levelLoader;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

        levelLoader = Finder.GetLevelLoader();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }

            isPaused = !isPaused;
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);

        foreach (GameObject canvas in canvases)
        {
            canvas.SetActive(false);
        }

        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);

        foreach (GameObject canvas in canvases)
        {
            canvas.SetActive(true);
        }

        Time.timeScale = 1f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;

        levelLoader.LoadCurrentLevel();
    }

    public void Menu()
    {
        Time.timeScale = 1f;

        levelLoader.LoadMenu();
    }
}
