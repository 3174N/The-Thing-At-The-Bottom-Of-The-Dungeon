using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        playerMovement player = other.GetComponent<playerMovement>();
        if (player != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
