using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    #region
    public Weapon currentWeapon;
    public StaminaBar staminaBar;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public GameObject deathMenu;

    public FixedJoystick joystick;

    float waitTime;

    public float damageBonus;
    public float GetDamage { get { return damageBonus + currentWeapon.damage; } }

    playerMovement player;
    float playerSpeed;

    Animator animator;
    SpriteRenderer spriteRenderer;
    #endregion

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        player = GetComponentInParent<playerMovement>();
        playerSpeed = player.playerSpeed;

        waitTime = currentWeapon.delay;

        staminaBar.SetMaxStamina(currentWeapon.delay);        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerSpeed < 15)
        {
            float test = Mathf.Pow((float)0.05 * playerSpeed, 2);
            waitTime = currentWeapon.delay - Mathf.Pow(0.1f * playerSpeed, 2f) + (2 * playerSpeed) - 1;
        }

        spriteRenderer.sprite = currentWeapon.sprite;

        if (joystick.Vertical != 0f || joystick.Horizontal != 0f)
        {
            if (waitTime <= 0)
            {
                animator.SetTrigger("Attack");

                currentWeapon.Attack(attackPoint, enemyLayers);

                waitTime = currentWeapon.delay;
                staminaBar.SetStamina(waitTime);
            }
        }

        waitTime -= Time.deltaTime;
        staminaBar.SetStamina(waitTime);
    }
    
    /// <summary>
    /// Changes the weapon
    /// </summary>
    /// <param name="weapon"></param>
    public void ChangeWeapon(Weapon weapon)
    {
        if (currentWeapon.weaponObject != null)
        {
            Vector2 newPos = new Vector2(transform.position.x + Random.Range(0, 1),
                    transform.position.y + Random.Range(0, 1));
            Instantiate(currentWeapon.weaponObject, newPos, Quaternion.identity);
        }

        currentWeapon = weapon;

        waitTime = currentWeapon.delay;
        staminaBar.SetMaxStamina(currentWeapon.delay);
    }

    private void OnDestroy()
    {
        deathMenu.SetActive(true);
    }

    public void ChangeDamage(float amount)
    {
        damageBonus += amount;
    }
}
