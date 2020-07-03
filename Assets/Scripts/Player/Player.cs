using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region variables 
    public bool hasKey = false;
    public Image keyIndicator;
    public Color keyColor;

    int coins;
    public int GetCoins { get { return coins; } }

    public Text[] coinTexts;

    GameManager gameManager;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        foreach (Text text in coinTexts)
        {
            text.text = coins.ToString();
        }

        keyIndicator.color = keyColor;

        gameManager = Finder.GetGameManager();
        coins = gameManager.startingCoins;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasKey)
            keyIndicator.color = Color.white;
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
