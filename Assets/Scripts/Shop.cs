using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    #region variables 
    public Material defaultM, highlight;

    public GameObject openButton;

    SpriteRenderer sprite;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
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

    public void Enter()
    {

    }
}
