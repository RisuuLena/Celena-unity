using UnityEngine;

public class BossCollisionProxy : MonoBehaviour
{
    public GameObject boss;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("Bullet hit detected");
            Bullet_up bullet = collision.gameObject.GetComponent<Bullet_up>();
            if (bullet != null)
            {
                Debug.Log("Bullet damage: " + bullet.damage);
                boss.GetComponent<Boss>().TakeDamage(bullet.damage);
                Destroy(collision.gameObject);
            }
            else
            {
                Debug.Log("Bullet script not found on collided object");
            }
        }
        
    }
}