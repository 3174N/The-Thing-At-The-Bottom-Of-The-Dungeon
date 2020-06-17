using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region variables 
    int coins;
    public int GetCoins { get { return coins; } }

    public Text[] coinTexts;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        foreach (Text text in coinTexts)
        {
            text.text = coins.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Changes the coins amount
    /// </summary>
    /// <param name="amount"></param>
    public void ChangeCoins(int amount)
    {
        coins += amount;

        foreach (Text text in coinTexts)
        {
            text.text = coins.ToString();
        }
    }
}
