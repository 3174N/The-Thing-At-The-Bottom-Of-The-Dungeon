using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    #region variables
    public GameObject key, healthBar;

    public float maxWaitTime;
    float waitTime;
    public float bossSpeed = 3f;

    bool isAttacking;
    bool playerIsIn;

    public float closeDistance = 7;

    Vector2 startPos;

    Player player;
    #endregion

    private void Awake()
    {
        startPos = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        waitTime = maxWaitTime;
        isAttacking = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        Destroy(Finder.FindClosestTag(transform, "Chest", closeDistance));
    }

    private void Update()
    {
        waitTime -= Time.deltaTime;

        if (waitTime <= 0 && !isAttacking && playerIsIn)
        {
            Vector2 direction = player.transform.position - transform.position;
            Attack();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            healthBar.SetActive(true);
            waitTime = maxWaitTime;
            playerIsIn = true;
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }

    void Attack()
    {
        isAttacking = true;

        //int rand = Random.Range(1, 3);
        int rand = 1;
        switch (rand)
        {
            case 1:
                /*float time = 1.5f;
                for (int i = 0; i < 3; i++)
                {
                    Vector2 direction = player.transform.position - transform.position;

                    while (time >= 0)
                    {
                        transform.position += (Vector3)direction;
                        time -= Time.deltaTime;
                    }

                    if (!(time <= -0.5))
                    { 
                        time -= Time.deltaTime;
                    }
                }*/
                break;
            case 2:
                // Attack 2
                break;
            case 3:
                // Attack 3
                break;
            default:
                break;
        }

        isAttacking = false;
        waitTime = maxWaitTime;
    }
}
