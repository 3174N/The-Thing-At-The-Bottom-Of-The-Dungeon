using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Text gems;

    public GameObject morePanel;

    // Update is called once per frame
    void Update()
    {
        gems.text = Finder.GetGameManager().gems.ToString();
    }

    public void GetGems(int amount)
    {
        if (Ads.RewardAd())
        {
            FindObjectOfType<GameManager>().gems += amount;
            FindObjectOfType<GameManager>().SaveShop();

        }
        else
        {
            Debug.Log("Can't display ad.");
            
            FindObjectOfType<AudioManager>().Play("Button");
        }
    }

    public void Move()
    {
        morePanel.SetActive(true);
    }

    public void Back()
    {
        morePanel.SetActive(false);
    }
}
