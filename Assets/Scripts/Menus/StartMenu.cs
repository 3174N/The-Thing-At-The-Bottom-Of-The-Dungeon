using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    #region variables
    public GameObject shopPanel, settingsPanel;
    GameObject activePanel;

    LevelLoader levelLoader;
    #endregion

    private void Start()
    {
        levelLoader = Finder.GetLevelLoader();
    }

    public void Launch()
    {
        levelLoader.LoadStart();
    }

    public void OpenShop()
    {
        shopPanel.SetActive(true);

        activePanel = shopPanel;
    }
    
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);

        activePanel = settingsPanel;
    }

    public void GoBack()
    {
        activePanel.SetActive(false);

        activePanel = null;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
