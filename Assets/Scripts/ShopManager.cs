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

    public void GetGems(int amount)
    {
        if (Ads.RewardAd())
        {
            Finder.GetGameManager().gems += amount;
        }
        else
        {
            Debug.Log("Can't display ad.");
        }
    }
}
