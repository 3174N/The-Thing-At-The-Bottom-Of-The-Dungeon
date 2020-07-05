using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Text gems;

    // Update is called once per frame
    void Update()
    {
        gems.text = Finder.GetGameManager().gems.ToString();
    }
}
