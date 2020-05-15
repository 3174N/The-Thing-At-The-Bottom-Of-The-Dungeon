using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public void ScrollR()
    {
        transform.position += new Vector3(10f, 0f, 0f);
    }

    public void ScrollL()
    {
        transform.position += new Vector3(-10f, 0f, 0f);
    }

    public void ScrollU()
    {
        transform.position += new Vector3(0f, 10f, 0f);
    }

    public void ScrollD()
    {
        transform.position += new Vector3(0f, -10f, 0f);
    }
}
