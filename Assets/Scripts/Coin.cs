using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    #region variables 
    public int amount;
    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            Apply(player);

            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Changes the coins amount
    /// </summary>
    /// <param name="player"></param>
    public void Apply(Player player)
    {
        player.ChangeCoins((int)amount);
    }
}
