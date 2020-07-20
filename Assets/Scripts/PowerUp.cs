using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    #region variables 
    public enum Type
    {
        Speed,
        Damage,
        Health
    }
    public Type type;
    public float amount;
    public float minPrice;
    public float maxPrice;

    public GameObject healthPop, damagePop, speedPop;
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

            FindObjectOfType<AudioManager>().Play("Powerup");

            Destroy(gameObject);
        }
    }

    public void Apply(playerMovement player)
    {
        if (type == Type.Speed)
        {
            player.ChangeSpeed(amount);
            GameObject pop = Instantiate(speedPop);
            Destroy(pop.gameObject, 1f);
        }
        else if (type == Type.Damage)
        {
            player.gameObject.GetComponentInChildren<PlayerCombat>().ChangeDamage(amount);
            GameObject pop = Instantiate(damagePop);
            Destroy(pop.gameObject, 1f);
        }
        else if (type == Type.Health)
        {
            player.gameObject.GetComponent<Combat>().ChangeHealth(amount);
            GameObject pop = Instantiate(healthPop);
            Destroy(pop.gameObject, 1f);
        }
    }

    public void Randomize()
    {
        int rand = Random.Range(1, 3);
        if (rand == 1)
        {
            type = Type.Damage;
            amount = 7;
        }
        else if (rand == 2)
        {
            type = Type.Speed;
            amount = 3;
        }
        else
        {
            type = Type.Health;
            amount = 20;
        }
    }
}
