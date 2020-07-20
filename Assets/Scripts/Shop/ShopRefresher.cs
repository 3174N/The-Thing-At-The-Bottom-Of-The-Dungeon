using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopRefresher : MonoBehaviour
{
    public ShopItem[] shopItems;

    public void Refresh()
    {
        if (Ads.RewardAd())
        {
            foreach (ShopItem item in shopItems)
            {
                item.Refresh();
            }
        }
        else
        {
            Debug.Log("Can't display ad");
        }
    }
}
