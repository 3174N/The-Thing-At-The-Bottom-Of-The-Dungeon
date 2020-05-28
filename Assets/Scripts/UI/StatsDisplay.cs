using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsDisplay : MonoBehaviour
{
    #region variables
    public Text healthText, speedText, damageText;
    public Text[] coinsTexts;

    Player player;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        UpdateStats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateStats()
    {
        healthText.text = "HEALTH: " + player.gameObject.GetComponent<Combat>().GetHealth.ToString() + " / " + player.GetComponent<Combat>().maxHealth.ToString();
        
        speedText.text = "SPEED: " + player.gameObject.GetComponent<playerMovement>().playerSpeed.ToString();
        
        damageText.text = "DAMAGE: " + player.gameObject.GetComponentInChildren<PlayerCombat>().GetDamage.ToString();

        foreach (Text text in coinsTexts)
        {
            text.text = player.GetCoins.ToString();
        }        
    }
}
