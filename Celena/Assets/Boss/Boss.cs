using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public int health = 500;
    public GameObject bullet;
    public Transform bulletPos;
    public float shootingInterval = 5.0f;
    public Flowchart flowchart; // Reference to the Fungus Flowchart
    public string dialogueBlockName = "BossDefeatedDialogue";
    
    private float timer;
    
    private Animator animator;

    private bool isShooting = false;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > shootingInterval)
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
        Debug.Log("Boss took damage, current health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        Debug.Log("Boss died");
        animator.SetTrigger("Death");
    }
    
    public void OnDeathAnimationEnd()
    {
        Debug.Log("OnDeathAnimationEnd called");
        TriggerDialogue();
    }

    void TriggerDialogue()
    {
        if (flowchart != null)
        {
            flowchart.ExecuteBlock(dialogueBlockName);
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
} 
    

