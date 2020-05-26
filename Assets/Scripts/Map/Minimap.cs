using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public GameObject minimap;
    public GameObject extendedMap;
    //public GameObject extendedCam;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ShowMap();
        }
        if (Input.GetKeyUp(KeyCode.M))
        {
            HideMap();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HideMap();
        }
    }

    /// <summary>
    /// Showing the Map
    /// </summary>
    public void ShowMap()
    {
        minimap.SetActive(false);

        extendedMap.SetActive(true);
        
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Showing the minimap
    /// </summary>
    public void HideMap()
    {
        minimap.SetActive(true);

        extendedMap.SetActive(false);
        
        Time.timeScale = 1f;
    }
}
