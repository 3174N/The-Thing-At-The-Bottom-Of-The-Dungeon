using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    public Transform enemy;
    public GameObject player;

    Rigidbody2D rigidbody2d;

    float angle;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get the direction to the player
        Vector2 direction = (Vector2)player.transform.position - rigidbody2d.position;

        // Rotate the point
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rigidbody2d.rotation = angle;
        //Debug.Log(angle);

        // The point is following the enemy
        rigidbody2d.position = enemy.position;
    }
}
