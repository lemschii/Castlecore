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
    public AnimationClip clip;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
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


