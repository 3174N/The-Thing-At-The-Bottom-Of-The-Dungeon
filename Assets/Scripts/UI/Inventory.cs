using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region variables
    public GameObject inventory;
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

        Time.timeScale = 0f;
    }

    /// <summary>
    /// Closes inventory
    /// </summary>
    public void Close()
    {
        inventory.SetActive(false);

        Time.timeScale = 1;
    }
}
