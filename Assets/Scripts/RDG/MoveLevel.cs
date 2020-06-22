using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveLevel : MonoBehaviour
{
    #region variables
    public GameObject moveButton;
    #endregion
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
