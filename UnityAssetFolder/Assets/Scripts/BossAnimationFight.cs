using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationFight : MonoBehaviour
{
    public Animator animator;
    public float attackRange = 0.5f;
    public int attackDamage = 50;
    public float attackRate = 2f;
    private float nextAttacktime = 0f;
    
    public int maxHealth;
    private int currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
