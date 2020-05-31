using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    #region variables
    public Weapon[] weapons;
    public Text priceText;

    public StatsDisplay inventory;

    int price;
    public int GetPrice { get { return price; } }

    Weapon weapon;
    GameObject[] takenWeapons;

    Image image;
    #endregion

    private void Start()
    {
        image = GetComponent<Image>();

        weapon = weapons[(int)Random.Range(0f, weapons.Length)];
          
        price = (int)Random.Range(weapon.price - 10f, weapon.price + 10f);
        priceText.text = price.ToString();

        image.sprite = weapon.sprite;
    }

    public void Buy()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        if (player.GetCoins >= price)
        {
            player.ChangeCoins(-price);
            player.gameObject.GetComponentInChildren<PlayerCombat>().ChangeWeapon(weapon);

            inventory.UpdateStats();

            Destroy(gameObject);
        }
        else
        {
            Debug.Log(player.GetCoins + " / " + price);
            // Need to find a way to inform the player
        }
    }
}
