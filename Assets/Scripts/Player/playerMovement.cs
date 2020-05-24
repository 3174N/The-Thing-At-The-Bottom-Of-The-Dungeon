using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float pS = 3.0f;
    public FixedJoystick joystick;

    Rigidbody2D rb;
    Vector2 m;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        m.x = Input.GetAxisRaw("Horizontal");
        m.y = Input.GetAxisRaw("Vertical");

        m.x = joystick.Horizontal;
        m.y = joystick.Vertical;
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + m * pS * Time.fixedDeltaTime);
    }

    public void ChangeSpeed(float amount)
    {
        pS += amount;
    }
}

