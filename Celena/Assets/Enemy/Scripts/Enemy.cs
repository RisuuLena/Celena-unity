using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public Transform player; 
    public float speed = 2.0f; 
    public float floatAmplitude = 0.5f; 
    public float floatFrequency = 1.0f; 
    public float stopDistance = 0.1f;
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    
    private float initialY; 
    
    private Animator animator;

    void Start()
    {
        initialY = transform.position.y;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player != null)
        { 
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            if (distanceToPlayer > stopDistance) {
                Vector2 direction = (player.position - transform.position).normalized;
                Vector2 newPosition = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

                float newY = initialY + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;

                transform.position = new Vector2(newPosition.x, newY);

                animator.Play("Enemy_Idle");
            }
            
        }
        timer += Time.deltaTime;
        if (timer > 2)
        {
            timer = 0;
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
    
    private void OnBecameInvisible()
    {
        enabled = false;
        Destroy(gameObject);
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

