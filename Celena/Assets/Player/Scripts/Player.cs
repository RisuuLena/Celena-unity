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

    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
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
    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed);
        rb.velocity = movement;
    }
}