using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public Animator animator;
    
    public float attackRange = 0.5f;
    public int attackDamage = 50;

    public float attackRate = 2f;
    private float nextAttacktime = 0f;
    
    public int maxHealth;
    private int currentHealth;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }
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
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("meomeoemeoemeo");

        //play hurt animation, die animation söbst gibts nu nid -> jonny 

        if (currentHealth <= 0)
        {
            Debug.Log("kyskyskyskys");
            Die();
        }
    }

    private void Die()
    {
        throw new System.NotImplementedException();
    }
}
