using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    public Transform player;

    float angle;

    Vector2 mousePos;
    Camera cam;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        cam = CameraFinder.getCam();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get the mouse position
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - rigidbody2d.position;

        // Rotate the point
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rigidbody2d.rotation = angle;

        // The point is following the player
        rigidbody2d.position = player.position;
    }
}
