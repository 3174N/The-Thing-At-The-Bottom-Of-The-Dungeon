using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    #region variables
    public GameObject key, healthBar;

    public float maxWaitTime;
    public float timeToReach;
    float waitTime;
    float time;

    float t;

    public float speed = 3f;

    bool isAttacking;
    bool playerIsIn;

    public float closeDistance = 7;

    public GameObject attackObject;
    Vector2 startPos;
    Vector2 newStartPos;
    Vector2 movement;
    Rigidbody2D rigidbody2;

    Player player;
    #endregion

    private void Awake()
    {
        startPos = newStartPos = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        waitTime = maxWaitTime;
        isAttacking = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rigidbody2 = GetComponent<Rigidbody2D>();

        Destroy(Finder.FindClosestTag(transform, "Chest", closeDistance));
    }

    private void Update()
    {
        waitTime -= Time.deltaTime;

        t += Time.deltaTime / timeToReach;

        if (waitTime <= 0 && !isAttacking && playerIsIn)
        {
            isAttacking = true;

            //int rand = Random.Range(1, 3);
            int rand = 2;
            switch (rand)
            {
                case 1:
                    for (int i = 0; i < 3; i++)
                    {
                        Vector2 playerPos = player.transform.position;
                        while (playerPos != (Vector2)transform.position)
                        {
                            Mover.MoveToPoint(transform, playerPos, speed);
                        }
                        time = 1.5f;
                        while (time >= 0)
                        {
                            time -= Time.deltaTime;
                            Debug.Log(time);
                        }
                        while ((Vector2)transform.position != startPos)
                        {
                            Mover.MoveToPoint(transform, startPos, speed);
                        }
                        Debug.Log(i);
                    }
                    break;
                case 2:
                    Instantiate(attackObject, transform.position, Quaternion.identity);
                    waitTime = maxWaitTime;
                    //Destroy(attackObject.gameObject, 10f);
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
        time -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveToPosition(transform, new Vector2(target.position.x, target.position.y), timeToReach);
            Debug.Log("dfs");
        }*/
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
        else if (collision.GetComponent<EnemyMovement>() != null)
        {
            Destroy(collision.gameObject);
        }
    }
}
