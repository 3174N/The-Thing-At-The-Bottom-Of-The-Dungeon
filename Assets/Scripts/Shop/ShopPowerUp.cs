using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPowerUp : MonoBehaviour
{
    #region variables
    public GameObject[] powerUps;
    public Text priceText;

    public StatsDisplay inventory;

    [SerializeField]
    int price;
    public int GetPrice { get { return price; } }

    PowerUp powerUp;
    
    Image image;
    #endregion

    private void Start()
    {
        image = GetComponent<Image>();

        powerUp = powerUps[(int)Random.Range(0f, powerUps.Length)].GetComponent<PowerUp>();
        Debug.Log(powerUp.name);

        price = (int)Random.Range(price - 10f, price + 10f);
        priceText.text = price.ToString();

        image.sprite = powerUp.gameObject.GetComponent<SpriteRenderer>().sprite;
        image.color = powerUp.gameObject.GetComponent<SpriteRenderer>().color;
    }

    public void Buy()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        if (player.GetCoins >= price)
        {
            player.ChangeCoins(-price);
            powerUp.Apply(player.gameObject.GetComponent<playerMovement>());
            
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
