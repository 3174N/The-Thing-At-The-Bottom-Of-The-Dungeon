using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("SHOP")]
    public int gems;

    [Header("STARTING BONUSES")]
    public int startingCoins;
    public int startingSpeed;
    public int maxHealth = 300;
    public int startingDamage;

    [Header("REWARDS")]
    public int enemies;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
