using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    #region variables
    public float speed = 3f;

    Vector2 movement;
    Vector2 lookDirection = new Vector2(1, 0);

    GameObject player;
    Rigidbody2D Rigidbody2;
    RoomDiscovery room;
    Animator animator;
    AudioSource source;
    bool isPlaying;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2 = GetComponent<Rigidbody2D>();
        room = GetComponentInParent<RoomDiscovery>();
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player != null)
        {
            movement = (Vector2)player.transform.position - Rigidbody2.position;

            if (!Mathf.Approximately(movement.x, 0.0f) || !Mathf.Approximately(movement.y, 0.0f))
            {
                lookDirection.Set(movement.x, movement.y);
                lookDirection.Normalize();

                if (!isPlaying && room.hasEntered)
                {
                    source.Play();
                    isPlaying = true;
                }
            }
            else
            {
                source.Stop();
                isPlaying = false;
            }

            animator.SetFloat("Look X", lookDirection.x);
            animator.SetFloat("Speed", movement.magnitude);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (room.hasEntered)
        {
            Rigidbody2.position += movement * speed * Time.fixedDeltaTime;
        }
    }
}
