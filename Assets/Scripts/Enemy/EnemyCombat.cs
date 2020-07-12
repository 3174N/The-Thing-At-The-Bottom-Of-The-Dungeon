using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public Weapon currentWeapon;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public Animator animator;

    SpriteRenderer spriteRenderer;

    float waitTime;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        waitTime = currentWeapon.delay;
    }

    // Update is called once per frame
    void Update()
    {
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
