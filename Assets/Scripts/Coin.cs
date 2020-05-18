using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    #region variables 
    public float amount;
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
        playerMovement player = other.GetComponent<playerMovement>();
        if (player != null)
        {
            Apply(player);

            Destroy(gameObject);
        }
    }

    public void Apply(playerMovement player)
    {
        player.gameObject.GetComponent<Player>().ChangeCoins((int)amount);
    }
}
