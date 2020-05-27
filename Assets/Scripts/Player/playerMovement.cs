using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    #region variables
    public float playerSpeed = 3.0f;
    public FixedJoystick joystick;

    Rigidbody2D rigidBody2;
    Vector2 movenent;    
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2 = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        movenent.x = Input.GetAxisRaw("Horizontal");
        movenent.y = Input.GetAxisRaw("Vertical");

        movenent.x = joystick.Horizontal;
        movenent.y = joystick.Vertical;
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        rigidBody2.MovePosition(rigidBody2.position + movenent * playerSpeed * Time.fixedDeltaTime);
    }

    /// <summary>
    /// Cahnges the speed of the player
    /// </summary>
    /// <param name="amount"></param>
    public void ChangeSpeed(float amount)
    {
        playerSpeed += amount;        
    }
}

