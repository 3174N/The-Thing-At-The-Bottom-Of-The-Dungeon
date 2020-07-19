using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveLevel : MonoBehaviour
{
    #region variables
    public GameObject moveButton;

    public bool tutorial;

    LevelLoader levelLoader;
    #endregion

    private void Start()
    {
        levelLoader = Finder.GetLevelLoader();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerMovement player = other.GetComponent<playerMovement>();
        if (player != null && player.GetComponent<Player>().hasKey)
        {
            moveButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        moveButton.SetActive(false);
    }

    public void Move()
    {
        if (tutorial)
            levelLoader.LoadStart();
        else
            levelLoader.LoadNextLevel();
    }
}
