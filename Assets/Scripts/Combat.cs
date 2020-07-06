using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat : MonoBehaviour
{
    #region variables
    public float maxHealth;
    public HealthBar healthBar;

    public GameObject[] DropOnDeath;
    public GameObject cameraDrop;

    public GameObject attackParticals;

    float currentHealth;
    public float GetHealth { get { return currentHealth; } }

    public Text healthText;

    Player player;
    bool isPLayer;

    GameManager gameManager;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        if (cameraDrop != null)
            cameraDrop.SetActive(false);

        player = GetComponent<Player>();
        if (player != null)
        {
            isPLayer = true;

            healthText.text = "HEALTH: " + currentHealth.ToString() + "/" + maxHealth.ToString();
        }

        gameManager = Finder.GetGameManager();
        if (isPLayer)
            maxHealth = gameManager.maxHealth;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // Cheks if object is dead
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Destroys the object if health is smaller or equel to 0
    /// </summary>
    void Die()
    {
        EnemyMovement enemy = GetComponent<EnemyMovement>();
        if (enemy != null || GetComponent<Boss>() != null)
        {
            isPLayer = false;

            if (enemy != null)
            {
                RoomLocker locker = GetComponentInParent<RoomLocker>();

                locker.enemies.Remove(enemy.gameObject);
                locker.CheckLock();
            }

            GameObject randomDrop = DropOnDeath[(int)Random.Range(0, DropOnDeath.Length)];
            Instantiate(randomDrop, transform.position, Quaternion.identity);
            
            Finder.GetGameManager().enemies += 1;
            
            Destroy(gameObject);
        }
        else
        {
            isPLayer = true;

            cameraDrop.SetActive(true);

            GetComponentInChildren<PlayerCombat>().OnDeath();

            currentHealth = 200;
            gameObject.SetActive(false);
        }
    }

    public void ChangeHealth(float amount)
    {
        currentHealth += amount;

        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        healthBar.SetHealth(currentHealth);

        if (isPLayer)
        {
            healthText.text = "HEALTH: " + currentHealth.ToString() + "/" + maxHealth.ToString();
        }

        if (amount < 0)
        {
            GameObject par = Instantiate(attackParticals, transform.position, Quaternion.identity);
            Destroy(par, 1f);
        }
    }

    public void ChangeMaxHealth(float amount)
    {
        maxHealth += amount;

        ChangeHealth(amount);

        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);

        if (isPLayer)
        {
            healthText.text = "HEALTH: " + currentHealth.ToString() + "/" + maxHealth.ToString();
        }
    }
}