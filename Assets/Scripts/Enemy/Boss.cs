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
    public GameObject attackObject2;
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

            int rand = UnityEngine.Random.Range(1, 3);
            switch (rand)
            {
                case 1:
                    GameObject attackClone = Instantiate(attackObject, transform.position, Quaternion.identity);
                    Destroy(attackClone, 5f);

                    waitTime = maxWaitTime;
                    break;
                case 2:
                    for (int i = 0; i < 3; i++)
                    {
                        attackClone = Instantiate(attackObject2, transform.position, Quaternion.identity);
                        Destroy(attackClone, 5f);
                    }
                    waitTime = maxWaitTime;
                    break;
                case 3:
                    waitTime = maxWaitTime;
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
