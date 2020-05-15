using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDiscovery : MonoBehaviour
{
    Animator animator;
    RoomLocker locker;

    public bool hasEntered;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        animator = GetComponent<Animator>();
        locker = GetComponent<RoomLocker>();

        hasEntered = false;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        playerMovement player = other.GetComponent<playerMovement>();

        if (player != null)
        {
            animator.SetBool("isDiscoverd", true);

            hasEntered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerMovement player = other.GetComponent<playerMovement>();

        if (player != null)
        {
            locker.CheckLock();
        }
    }
}
