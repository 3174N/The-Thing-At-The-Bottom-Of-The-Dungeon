using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Advertisement.IsReady("rewardedVideo"))
            {
                Debug.Log("ready");
                Advertisement.Show("rewardedVideo");
            }
            else
            {
                Debug.Log("not ready");
            }
        }
    }

    public static bool RewardAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            Advertisement.Show("rewardedVideo");

            return true;
        }
        else
        {
            return false;
        }
    }
}
