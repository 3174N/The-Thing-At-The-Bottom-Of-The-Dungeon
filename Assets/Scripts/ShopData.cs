using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopData
{
    public bool sfx;
    public bool music;

    public int gems;

    public int speedUses;
    public int damageUses;
    public int healthUses;
    public int coinsUses;

    public int speedPrice;
    public int damagePrice;
    public int healthPrice;
    public int coinsPrice;

    public ShopData(GameManager manager)
    {
        sfx = manager.sfxOn;
        music = manager.musicOn;

        gems = manager.gems;

        speedUses = manager.speedUses;
        damageUses = manager.damageUses;
        healthUses = manager.healthUses;
        coinsUses = manager.coinsUses;

        speedPrice = manager.speedPrice;
        damagePrice = manager.damagePrice;
        healthPrice = manager.healthPrice;
        coinsPrice = manager.coinsPrice;
    }
}
