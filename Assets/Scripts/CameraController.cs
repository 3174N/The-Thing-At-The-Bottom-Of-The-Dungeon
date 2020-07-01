using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 3;
    float waitTime = 2f;
    float counter = 0;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;

        if (waitTime <= 0)
        {
            waitTime = 2f;
            counter += 1;

            if (counter % 4 == 0)
                movement.Set(1f, 1f);
            else if (counter % 4 == 1)
                movement.Set(1f, -1f);
            else if (counter % 4 == 2)
                movement.Set(-1f, -1f);
            else if (counter % 4 == 3)
                movement.Set(-1f, 1f);
        }
    }

    private void FixedUpdate()
    {
        transform.position += (Vector3)movement * speed * Time.deltaTime;
    }
}
