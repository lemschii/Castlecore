using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossmovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed of movement towards the player
    public float burstDuration = 2f;  // Duration of each movement burst
    public float waitDuration = 5f;  // Duration to wait between bursts
    public Animator animator;
    public Transform slimeTransform;

    private Transform player;  // Reference to the player's transform
    private Vector3 moveDirection;  // Direction to move towards the player
    private float burstTimer;  // Timer for measuring burst duration
    private float waitTimer;  // Timer for measuring wait duration
    
    public float attackRange = 10f;
    public int attackDamage = 50;
    public float attackRate = 2f;
    private float nextAttacktime = 0f;
    
    public int maxHealth;
    private int currentHealth;
    
    public LayerMask enemyLayers;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        burstTimer = burstDuration;  // Start by moving immediately
        waitTimer = waitDuration;  // Start waiting after the first burst
        animator = GetComponent<Animator>();
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
        Debug.Log("rawr xDDDD Lollll :> Blehhh :PPPP >.<");
        //detect if player is in dash range (SCHAUN OB DIE RANGE PASST, WEILS JO VOM TRANSFORM AUSGEHT) 
        Collider2D hitEnemies = Physics2D.OverlapCircle(transform.position, 100f, enemyLayers);
        
        if (burstTimer > 0f && hitEnemies)
        {
            Debug.Log("Meiow");
            // Calculate direction towards the player
            moveDirection = (player.position - transform.position).normalized;
            
            // Move towards the player during the burst
            float moveDistance = moveSpeed * Time.deltaTime;
            transform.position += moveDirection * moveDistance;
            
            burstTimer -= Time.deltaTime;  // Decrease burst timer
            
            Collider2D[] hitplayer = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayers);
            //Damage Calculation
            foreach (Collider2D enemy in hitplayer)
            {
                animator.SetTrigger("IsHittingPlayer");
                //Debug.Log("Hit  " + enemy.name);
                enemy.GetComponent<PlayerCombat>().TakeDamage(attackDamage);
            }
            //detetct if player is in damage range
            
        }
        else
        {
            // If burst duration is over, start waiting
            if (waitTimer > 0f)
            {
                waitTimer -= Time.deltaTime;  // Decrease wait timer
            }
            else
            {
                // Reset burst timer and wait timer for the next burst
                burstTimer = burstDuration;
                waitTimer = waitDuration;
            }
        }
    }
}
