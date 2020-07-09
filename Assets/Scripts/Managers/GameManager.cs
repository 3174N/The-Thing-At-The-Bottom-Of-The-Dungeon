using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("SETTINGS")]
    public bool musicOn;
    public bool sfxOn;

    [Header("SHOP")]
    public int gems;

    public int speedUses;
    public int damageUses;
    public int healthUses;
    public int coinsUses;

    public int speedPrice = 50;
    public int damagePrice = 50;
    public int healthPrice = 50;
    public int coinsPrice = 50;

    [Header("STARTING BONUSES")]
    public int startingCoins;
    public int startingSpeed;
    public int maxHealth = 300;
    public int startingDamage;

    [Header("REWARDS")]
    public int enemies;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //LoadShop();
    }

    public void SaveShop()
    {
        SaveSystem.SaveShop(this);
    }

    public void LoadShop()
    {
        ShopData data = SaveSystem.LoadShop();

        sfxOn = data.sfx;
        musicOn = data.music;

        gems = data.gems;

        speedUses = data.speedUses;
        damageUses = data.damageUses;
        healthUses = data.healthUses;
        coinsUses = data.coinsUses;

        speedPrice = data.speedPrice;
        damagePrice = data.damagePrice;
        healthPrice = data.healthPrice;
        coinsPrice = data.coinsPrice;
    }
}
