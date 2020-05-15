using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;

    GameObject player;

    Rigidbody2D Rigidbody2;

    RoomDiscovery room;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2 = GetComponent<Rigidbody2D>();
        room = GetComponentInParent<RoomDiscovery>();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (room.hasEntered)
        {
            Vector2 movement = (Vector2)player.transform.position - Rigidbody2.position;

            Rigidbody2.position += movement * speed * Time.fixedDeltaTime;
        }
    }
}
