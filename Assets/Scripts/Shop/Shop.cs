using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    #region variables 
    public Material defaultM, highlight;

    public GameObject openButton;

    public StatsDisplay inventory;
    
    [SerializeField]
    GameObject shop;

    SpriteRenderer sprite;

    RoomLocker room;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        room = GetComponentInParent<RoomLocker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<playerMovement>())
        {            
            openButton.SetActive(true);

            sprite.material = highlight;            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<playerMovement>())
        {
            openButton.SetActive(false);

            sprite.material = defaultM;
        }
    }

    /// <summary>
    /// Opens the shop
    /// </summary>
    public void EnterShop()
    {
        shop.SetActive(true);

        inventory.UpdateStats();
    }

    /// <summary>
    /// Closes the shop
    /// </summary>
    public void ExitShop()
    {
        shop.SetActive(false);
    }
}
