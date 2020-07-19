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
        if (!FindObjectOfType<GameManager>().hasTutorial)
            levelLoader.LoadTutorial();
        else
            levelLoader.LoadStart();

        GameObject.FindObjectOfType<GameManager>().SaveShop();
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
        GameObject.FindObjectOfType<GameManager>().SaveShop();

        Application.Quit();
    }

    public void MainMenu()
    {
        GameObject.FindObjectOfType<GameManager>().SaveShop();

        SceneManager.LoadScene("Menu");
    }
}
