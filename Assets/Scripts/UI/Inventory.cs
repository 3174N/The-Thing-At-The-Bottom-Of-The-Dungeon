using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region variables
    public GameObject inventory;

    public GameObject[] canvases;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Opens inventory 
    /// </summary>
    public void Open()
    {
        inventory.SetActive(true);

        foreach (GameObject canvas in canvases)
        {
            canvas.SetActive(false);
        }

        Time.timeScale = 0f;
    }

    /// <summary>
    /// Closes inventory
    /// </summary>
    public void Close()
    {
        inventory.SetActive(false);

        foreach (GameObject canvas in canvases)
        {
            canvas.SetActive(true);
        }

        Time.timeScale = 1;
    }
}
