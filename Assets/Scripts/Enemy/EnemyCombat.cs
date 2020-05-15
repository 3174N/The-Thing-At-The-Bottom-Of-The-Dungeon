using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public Weapon currentWeapon;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    Animator animator;

    SpriteRenderer spriteRenderer;

    float waitTime;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        waitTime = currentWeapon.delay;
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sprite = currentWeapon.sprite;

        if (waitTime <= 0)
        {
            animator.SetTrigger("Attack");

            currentWeapon.Attack(attackPoint, enemyLayers);

            waitTime = currentWeapon.delay;
        }

        waitTime -= Time.deltaTime;
    }

    /// <summary>
    /// Changes the weapon
    /// </summary>
    /// <param name="weapon"></param>
    void ChangeWeapon(Weapon weapon)
    {
        currentWeapon = weapon;

        waitTime = currentWeapon.delay;
    }
}
