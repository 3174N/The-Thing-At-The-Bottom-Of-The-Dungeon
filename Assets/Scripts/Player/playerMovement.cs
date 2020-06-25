using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    #region variables
    public float playerSpeed = 3.0f;
    public FixedJoystick joystick;

    public Text speedText;
    public Transform point;

    public float timeToMove;

    Rigidbody2D rigidBody2;
    Vector2 movenent;    
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2 = GetComponent<Rigidbody2D>();

        speedText.text = playerSpeed.ToString();
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

        speedText.text = playerSpeed.ToString();
    }
}

