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

    public static GameObject FindClosestTag(Transform transform ,string tag, float closeDistance)
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tag);

        for (int i = 0; i < taggedObjects.Length; i++)
        {
            if (Vector3.Distance(transform.position,
                     taggedObjects[i].transform.position) <= closeDistance)
            {
                Debug.Log(taggedObjects[i]);
                return taggedObjects[i];
            }
        }

        return null;
    }
}
