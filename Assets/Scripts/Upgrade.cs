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
    int used;

    public Text bonusText;
    public Text usesText;
    public Text priceText;

    private void Start()
    {
        bonusText.text = "+" + amount;
        usesText.text = used + " / " + uses;
        priceText.text = price.ToString();
    }

    public void Buy()
    {
        if (used >= uses || price > Finder.GetGameManager().gems)
            return;

        used += 1;

        if (coins)
        {
            Finder.GetGameManager().startingCoins += amount;
        }
        else if (speed)
        {
            Finder.GetGameManager().startingSpeed += amount;
        }
        else if (health)
        {
            Finder.GetGameManager().maxHealth += amount;
        }
        else if (damage)
        {
            Finder.GetGameManager().startingDamage += amount;
        }

        usesText.text = used + " / " + uses;

        Finder.GetGameManager().gems -= price;
        price *= 2;
        priceText.text = price.ToString();
    }
}
