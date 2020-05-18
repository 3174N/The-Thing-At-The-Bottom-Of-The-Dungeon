using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    #region variables 
    public Material defaultM, highlight;

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
        sprite.material = highlight;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        sprite.material = defaultM;
    }

    public void Enter()
    {

    }
}
