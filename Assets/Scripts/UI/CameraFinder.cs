using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFinder : MonoBehaviour
{
    public static Camera getCam()
    {
        return GameObject.FindGameObjectWithTag("MainCam").GetComponent<Camera>(); 
    }
}
