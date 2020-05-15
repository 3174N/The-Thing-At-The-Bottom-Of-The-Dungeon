using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLocker : MonoBehaviour
{
    public GameObject[] doorColliders;

    float waitTime = 3f;
    bool isOpen;

    public List<GameObject> enemies;

    private void Start()
    {
        
    }

    private void Update()
    {
        waitTime -= Time.deltaTime;

        if (waitTime <= 0)
        {
            CheckLock();

            waitTime =  3f;
        }
    }

    /// <summary>
    /// Checks if these are enemies in the room, and if so - locks the room
    /// </summary>
    public void CheckLock()
    {
        if (enemies.Count <= 0)
        {
            foreach (GameObject i in doorColliders)
            {
                i.SetActive(false);

                isOpen = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();
        if (enemies.Contains(other.gameObject) || enemy == null)
            return;

        enemies.Add(other.gameObject);
    }

    public bool getIsOpen()
    {
        return isOpen;
    }
}
