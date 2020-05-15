using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedRoom : MonoBehaviour
{
    public Transform openingRoom;

    // Update is called once per frame
    void Update()
    {
        if (transform.position == openingRoom.position)
        {
            Destroy(gameObject);
        }
    }
}
