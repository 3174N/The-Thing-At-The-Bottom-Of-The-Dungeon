using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finder : MonoBehaviour
{
    public static Camera getCam()
    {
        return Camera.main; 
    }

    public static StatsDisplay GetInventory()
    {
        return GameObject.FindGameObjectWithTag("Inventory").GetComponent<StatsDisplay>();
    }

    public static GameObject GetShop()
    {
        return GameObject.FindGameObjectWithTag("Shop");
    }
}
