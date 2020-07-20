using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    #region variables
    public enum Sell
    {
        Weapons,
        Powerups
    }

    public Sell sell;
    public Weapon[] weapons;
    public GameObject[] powerUps;

    public Text priceText;

    int price;
    public int GetPrice { get { return price; } }

    Weapon weapon;
    GameObject powerUp;
    GameObject[] takenWeapons;

    Image image;
#endregion

    private void Start()
    {
        image = GetComponent<Image>();

        if (sell == Sell.Weapons)
        {
            weapon = weapons[(int)Random.Range(0f, weapons.Length)];
            price = (int)Random.Range(weapon.minPrice, weapon.maxPrice);
            image.sprite = weapon.sprite;
        }
        else
        {
            powerUp = powerUps[(int)Random.Range(0f, powerUps.Length)];
            price = (int)Random.Range(powerUp.GetComponent<PowerUp>().minPrice, powerUp.GetComponent<PowerUp>().maxPrice);
            image.sprite = powerUp.GetComponent<SpriteRenderer>().sprite;
        }
           
        priceText.text = price.ToString();
    }

    public void Refresh()
    {
        gameObject.SetActive(true);

        if (sell == Sell.Weapons)
        {
            weapon = weapons[(int)Random.Range(0f, weapons.Length)];
            price = (int)Random.Range(weapon.minPrice, weapon.maxPrice);
            image.sprite = weapon.sprite;
        }
        else
        {
            powerUp = powerUps[(int)Random.Range(0f, powerUps.Length)];
            price = (int)Random.Range(powerUp.GetComponent<PowerUp>().minPrice, powerUp.GetComponent<PowerUp>().maxPrice);
            image.sprite = powerUp.GetComponent<SpriteRenderer>().sprite;
        }

        priceText.text = price.ToString();
    }

    public void Buy()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        if (player.GetCoins >= price)
        {
            player.ChangeCoins(-price);

            if (sell == Sell.Weapons)
                player.gameObject.GetComponentInChildren<PlayerCombat>().ChangeWeapon(weapon);
            else
            {
                powerUp.GetComponent<PowerUp>().Apply(player.GetComponent<playerMovement>());
            }

            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log(player.GetCoins + " / " + price);
            // Need to find a way to inform the player
        }
    }
}
