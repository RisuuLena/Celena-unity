using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_up : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 20;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        enabled = false;
        Destroy(gameObject);
    }
}