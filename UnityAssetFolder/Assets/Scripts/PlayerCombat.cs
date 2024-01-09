using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask enemyLayers;
    
    public float attackRange = 0.5f;
    public int attackDamage = 50;

    public float attackRate = 2f;
    private float nextAttacktime = 0f;
    
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttacktime)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                Attack();
                nextAttacktime = Time.time + 1f / attackRate;
            }
        }
        
    }
    
    private void Attack()
    {
        //Attack Animation
        
        //Detect Enemies in Range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
        //Damage Calculation
        foreach (Collider2D enemy in hitEnemies)
        {
            //Debug.Log("Hit  " + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }
}
