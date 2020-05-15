using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObject : MonoBehaviour
{
    public Weapon weapon;
    public GameObject swapButton;

    public Material highlight, defult;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        swapButton.SetActive(false);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        spriteRenderer.sprite = weapon.sprite;
    }

    /// <summary>
    /// Called when player enter collider
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay2D(Collider2D other)
    {
        PlayerCombat player = other.GetComponentInChildren<PlayerCombat>();
        if (player != null)
        {
            swapButton.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                ChangeWeapon();
            }

            spriteRenderer.material = highlight;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerCombat player = other.GetComponentInChildren<PlayerCombat>();
        if (player != null)
        {
            spriteRenderer.material = defult;

            swapButton.SetActive(false);
        }
    }

    /// <summary>
    /// Change the player's weapon
    /// </summary>
    public void ChangeWeapon()
    {
        PlayerCombat player;

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        player = GetPLayer(players);

        if (player != null)
        {
            player.ChangeWeapon(weapon);

            swapButton.SetActive(false);
            Destroy(gameObject);
        }
        
    }

    PlayerCombat GetPLayer(GameObject[] players)
    {
        foreach (GameObject i in players)
        {
            if (i.GetComponent<PlayerCombat>() != null)
            {
                return i.GetComponent<PlayerCombat>();
            }
        }

        return null;
    }
}
