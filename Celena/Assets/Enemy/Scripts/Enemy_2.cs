using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : MonoBehaviour
{
    public int health = 60;
    public Transform player; 
    public float speed = 2.0f; 
    public float floatAmplitude = 0.5f; 
    public float floatFrequency = 3.0f; 
    public float stopDistance = 0.1f;
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    
    private float initialY; 
    
    private Animator animator;

    private bool isShooting = false;

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
        if (!isShooting)
        {
            StartCoroutine(Shoot());
        }
    }
    
    IEnumerator Shoot()
    {
        isShooting = true;
        animator.SetBool("isShooting", true);
        
        // Wait for the animation state to start playing
        yield return new WaitForEndOfFrame();
        
        // Get the animation length of the current state
        float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;

        // Wait for the animation to finish
        yield return new WaitForSeconds(animationLength);
        
        isShooting = false;
        animator.SetBool("isShooting", false);
    }

    public void InstantiateBullet()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
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
        animator.SetTrigger("Death");
    }

    public void OnDeathAnimationEnd()
    {
        Destroy(gameObject);
    }
}
