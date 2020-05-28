using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region variables 
    int coins;
    public int GetCoins { get { return coins; } }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
