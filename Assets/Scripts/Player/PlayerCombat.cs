using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Weapon currentWeapon;
    public StaminaBar staminaBar;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public GameObject deathMenu;

    Animator animator;

    SpriteRenderer spriteRenderer;

    float waitTime;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        waitTime = currentWeapon.delay;

        staminaBar.SetMaxStamina(currentWeapon.delay);
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sprite = currentWeapon.sprite;

        if (Input.GetMouseButtonDown(0) /*&& waitTime <= 0*/)
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
        Vector2 newPos = new Vector2(transform.position.x + Random.Range(0, 1),
                transform.position.y + Random.Range(0, 1));
        Instantiate(currentWeapon.weaponObject, newPos, Quaternion.identity);

        currentWeapon = weapon;

        waitTime = currentWeapon.delay;
        staminaBar.SetMaxStamina(currentWeapon.delay);
    }

    private void OnDestroy()
    {
        deathMenu.SetActive(true);
    }
}
