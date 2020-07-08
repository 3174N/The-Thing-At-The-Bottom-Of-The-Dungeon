using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    #region variables
    public GameObject pauseMenu;
    public GameObject deathMenu;
    public GameObject[] canvases;

    public GameObject player;
    public GameObject cameraDrop;

    bool isPaused;
    bool hasRevived;

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

        GameObject.FindObjectOfType<GameManager>().SaveShop();

        levelLoader.LoadCurrentLevel();
    }

    public void Revive()
    {
        if (!hasRevived)
        {
            if (Ads.RewardAd())
            {
                cameraDrop.SetActive(false);
                player.SetActive(true);

                hasRevived = true;

                deathMenu.SetActive(false);

                foreach (GameObject canvas in canvases)
                {
                    canvas.SetActive(true);
                }
            }
            else
            {
                Debug.Log("Cannot revive!");
            }
        }
        else
        {
            Debug.Log("Cannot revive!");
        }
    }

    public void Menu()
    {
        Time.timeScale = 1f;

        GameObject.FindObjectOfType<GameManager>().SaveShop();

        levelLoader.LoadMenu();
    }
}
