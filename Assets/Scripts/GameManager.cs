using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("SHOP")]
    public int gems;
    public Text gemsText;

    [Header("STARTING BONUSES")]
    public int startingCoins;
    public int startingSpeed;
    public int maxHealth = 300;
    public int startingDamage;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        gemsText.text = gems.ToString();
    }
}
