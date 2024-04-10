using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth;
    private int currentHealth;
    public EnemyPatrol enemypatrol;
  
    public Transform attackPoint;
    public LayerMask enemyLayers;
    
    public float attackRange = 0.5f;
    public int attackDamage = 50;

    public float attackRate = 2f;
    private float nextAttacktime = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    
    void Update()
    {
        if (Time.time >= nextAttacktime)
        {
            Attack();
            nextAttacktime = Time.time + 1f / attackRate;
        }
        
    }

    private void Attack()
    {
        //Detect Enemies in Range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
        //Damage Calculation
        foreach (Collider2D enemy in hitEnemies)
        {
            animator.SetTrigger("IsHittingPlayer");
            //Debug.Log("Hit  " + enemy.name);
            enemy.GetComponent<PlayerCombat>().TakeDamage(attackDamage);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //play hurt animation
        animator.SetTrigger("IsHurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
       Debug.Log("You killed " + this.name);
       
       
        //die animation
        animator.SetBool("IsDead", true);
        Debug.Log("Animator IsDead" + animator.GetBool("IsDead"));
        
        //disable Patrol
        enemypatrol.enabled = false;
        //disable enemy
        gameObject.layer = 6;
        
        Debug.Log("PostEnabledFalse");
        
    }

    
}


