using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public Transform player; // Reference to the player's transform
    public float speed = 2.0f; // Speed at which the enemy moves towards the player
    public float floatAmplitude = 0.5f; // Amplitude of the up and down movement
    public float floatFrequency = 1.0f; // Frequency of the up and down movement

    private float initialY; // Store the initial Y position

    void Start()
    {
        // Store the initial Y position of the enemy
        initialY = transform.position.y;
    }

    void Update()
    {
        if (player != null)
        {
            // Move towards the player
            Vector2 direction = (player.position - transform.position).normalized;
            Vector2 newPosition = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            // Add floating up and down effect
            float newY = initialY + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;

            // Set the new position
            transform.position = new Vector2(newPosition.x, newY);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
