using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region variables
    public GameObject inventory;

    StatsDisplay sInventory;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        sInventory = inventory.GetComponent<StatsDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        inventory.SetActive(true);

        sInventory.UpdateStats();

        Time.timeScale = 0f;
    }

    public void Close()
    {
        inventory.SetActive(false);

        Time.timeScale = 1;
    }
}
