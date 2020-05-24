using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    #region variables
    public Transform player;

    public FixedJoystick joystick;

    Rigidbody2D rigidbody2d;

    float angle;

    Vector2 mousePos;
    Vector2 attackDir;

    Camera cam;
    #endregion

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        // cam = CameraFinder.getCam();
    }

    private void Update()
    {
        attackDir = new Vector2(joystick.Vertical, joystick.Horizontal);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get the mouse position
        //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //Vector2 direction = mousePos - rigidbody2d.position;
        Vector2 direction = attackDir;

        // Rotate the point
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rigidbody2d.rotation = -(angle + 90f);

        // The point is following the player
        rigidbody2d.position = player.position;
    }
}
