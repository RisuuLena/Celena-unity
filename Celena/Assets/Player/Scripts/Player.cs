using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    public float moveSpeed = 8f;
    public int health = 100;

    public HealthBar healthBar;
    public GameManager gameManager;

    private Rigidbody2D rb;
    private Animator animator;

    private bool isDead;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthBar.SetHealth(health);
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);

        if (health <= 0 && !isDead)
        {
            isDead = true;
            Die();
            gameManager.gameOver();
        }
    }
    
    void Die()
    {
        Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed);
        rb.velocity = movement;
    }
}