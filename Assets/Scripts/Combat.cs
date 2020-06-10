﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    #region variables
    public float maxHealth;
    public HealthBar healthBar;
    
    public bool isDead;
    public GameObject[] DropOnDeath;

    float currentHealth;
    public float GetHealth { get { return currentHealth; } }       
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        isDead = false;        
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // Cheks if object is dead
        if (isDead || currentHealth <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Change the object's health
    /// </summary>
    /// <param name="amount"></param>
    public void ChangeHealth(float amount)
    {
        currentHealth += amount;

        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        healthBar.SetHealth(currentHealth);        
    }

    /// <summary>
    /// Destroys the object if health is smaller or equel to 0
    /// </summary>
    void Die()
    {
        isDead = true;

        EnemyMovement enemy = GetComponent<EnemyMovement>();
        if (enemy != null)
        {
            // GameObject.FindGameObjectWithTag("Player").GetComponent<Combat>().ChangeHealth(15);

            RoomLocker locker = GetComponentInParent<RoomLocker>();

            locker.enemies.Remove(enemy.gameObject);
            locker.CheckLock();

            GameObject randomDrop = DropOnDeath[(int)Random.Range(0, DropOnDeath.Length)];
            Instantiate(randomDrop, transform.position, Quaternion.identity);
            Debug.Log("droped" + randomDrop + transform.position);
        }

        Destroy(gameObject);
    }

    public void ChangeMaxHealth(float amount)
    {
        maxHealth += amount;

        ChangeHealth(amount);

        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
    }
}
