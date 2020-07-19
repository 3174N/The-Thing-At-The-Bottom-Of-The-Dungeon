using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("TUTORIAL")]
    public bool hasTutorial;

    [Header("SETTINGS")]
    public bool musicOn;
    public bool sfxOn;

    public Code[] codes;

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
    public float startingSpeed;
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
        LoadShop();
    }

    public void SaveShop()
    {
        SaveSystem.SaveShop(this);
    }

    public void LoadShop()
    {
        ShopData data = SaveSystem.LoadShop();

        hasTutorial = data.hasTutorial;

        sfxOn = data.sfx;
        musicOn = data.music;

        codes = data.codes;

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

    public void Submit(string input)
    {
        Code code = Array.Find(codes, c => c.code == input.ToLower());
        if (code == null)
        {
            return;
        }

        code.isUsed = true;
        FindObjectOfType<GameManager>().gems += code.amount;
    }
}
