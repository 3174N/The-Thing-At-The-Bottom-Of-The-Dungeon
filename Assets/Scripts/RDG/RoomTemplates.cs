using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public List<GameObject> rooms;

    public GameObject boss;
    public GameObject closedRoom;
    public float waitTime;
    private bool spawnedBoss;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        waitTime -= Time.deltaTime;

        if (waitTime <= 0)
        {
            if (rooms.Count < 10)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            for (int i = 0; i <= rooms.Count; i++)
            {
                if (i == rooms.Count && !spawnedBoss)
                {
                    Instantiate(boss, rooms[i - 1].transform.position, Quaternion.identity);

                    spawnedBoss = true;
                }
            }
        }
    }
        
}
