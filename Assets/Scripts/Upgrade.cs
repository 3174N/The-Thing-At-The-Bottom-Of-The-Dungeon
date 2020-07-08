using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public bool speed, health, damage, coins;
    public int amount;

    public int price;

    public int uses;

    public Text bonusText;
    public Text usesText;
    public Text priceText;

    private void Start()
    {
        bonusText.text = "+" + amount;

        if (speed)
        {
            price = Finder.GetGameManager().speedPrice;
        }
        else if (damage)
        {
            price = Finder.GetGameManager().damagePrice;
        }
        else if (health)
        {
            price = Finder.GetGameManager().healthPrice;
        }
        else if (coins)
        {
            price = Finder.GetGameManager().coinsPrice;
        }
        priceText.text = price.ToString();

        if (coins)
        {
            usesText.text = Finder.GetGameManager().coinsUses + " / " + uses;
        }
        else if (speed)
        {
            usesText.text = Finder.GetGameManager().speedUses + " / " + uses;
        }
        else if (health)
        {
            usesText.text = Finder.GetGameManager().healthUses + " / " + uses;
        }
        else if (damage)
        {
            usesText.text = Finder.GetGameManager().damageUses + " / " + uses;
        }
    }

    public void Buy()
    {
        if (coins)
        {
            if (Finder.GetGameManager().coinsUses >= uses || price > Finder.GetGameManager().gems)
                return;

            Finder.GetGameManager().startingCoins += amount;

            Finder.GetGameManager().coinsUses += 1;
            usesText.text = Finder.GetGameManager().coinsUses + " / " + uses;
        }
        else if (speed)
        {
            if (Finder.GetGameManager().speedUses >= uses || price > Finder.GetGameManager().gems)
                return;

            Finder.GetGameManager().startingSpeed += amount;

            Finder.GetGameManager().speedUses += 1;
            usesText.text = Finder.GetGameManager().speedUses + " / " + uses;
        }
        else if (health)
        {
            if (Finder.GetGameManager().healthUses >= uses || price > Finder.GetGameManager().gems)
                return;

            Finder.GetGameManager().maxHealth += amount;

            Finder.GetGameManager().healthUses += 1;
            usesText.text = Finder.GetGameManager().healthUses + " / " + uses;
        }
        else if (damage)
        {
            if (Finder.GetGameManager().damageUses >= uses || price > Finder.GetGameManager().gems)
                return;

            Finder.GetGameManager().startingDamage += amount;

            Finder.GetGameManager().damageUses += 1;
            usesText.text = Finder.GetGameManager().damageUses + " / " + uses;
        }

        Finder.GetGameManager().gems -= price;
        price *= 2;
        priceText.text = price.ToString();

        if (speed)
        {
            Finder.GetGameManager().speedPrice = price;
        }
        else if (damage)
        {
            Finder.GetGameManager().damagePrice = price;
        }
        else if (health)
        {
            Finder.GetGameManager().healthPrice = price;
        }
        else if (coins)
        {
            Finder.GetGameManager().coinsPrice = price;
        }

        GameObject.FindObjectOfType<GameManager>().SaveShop();
    }
}
