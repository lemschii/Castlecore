using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossmovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed of movement towards the player
    public float burstDuration = 2f;  // Duration of each movement burst
    public float waitDuration = 5f;  // Duration to wait between bursts

    private Transform player;  // Reference to the player's transform
    private Vector3 moveDirection;  // Direction to move towards the player
    private float burstTimer;  // Timer for measuring burst duration
    private float waitTimer;  // Timer for measuring wait duration

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        burstTimer = burstDuration;  // Start by moving immediately
        waitTimer = waitDuration;  // Start waiting after the first burst
    }

    void Update()
    {
        // Calculate direction towards the player
        moveDirection = (player.position - transform.position).normalized;

        if (burstTimer > 0f)
        {
            // Move towards the player during the burst
            float moveDistance = moveSpeed * Time.deltaTime;
            transform.position += moveDirection * moveDistance;

            burstTimer -= Time.deltaTime;  // Decrease burst timer
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
