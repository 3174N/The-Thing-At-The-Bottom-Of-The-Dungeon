using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    #region variables
    public Sprite sprite;

    public int damage;
    public float range;
    public float delay;

    public GameObject weaponObject;

    public int price;
    #endregion

    /// <summary>
    /// Attacks enemies
    /// </summary>
    /// <param name="attackPoint"></param>
    /// <param name="enemyLayers"></param>
    public void Attack(Transform attackPoint, LayerMask enemyLayers)
    {
        Vector2 center = new Vector2(1.5f, range);

        //Detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPoint.position, center, attackPoint.rotation.z, enemyLayers);

        //Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<Combat>() != null)
            {
                enemy.GetComponent<Combat>().ChangeHealth(-damage);
            }
        }
    }
}
