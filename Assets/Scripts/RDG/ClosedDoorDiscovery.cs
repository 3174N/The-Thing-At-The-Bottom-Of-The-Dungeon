using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedDoorDiscovery : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerMovement player = other.GetComponent<playerMovement>();
        if (player != null)
        {
            animator.SetBool("HasCollided", true);
        }
    }
}
