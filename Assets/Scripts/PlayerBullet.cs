using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float bulletSpeed = 8f;
    public int bulletDamage = 8;

    void Update()
    {
        // Move bullet upwards
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);

        // Destroy bullet if it goes off-screen
        Vector2 maxPosition = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        if (transform.position.y > maxPosition.y)
        {
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Deal damage to the enemy
            Debug.Log(collision.CompareTag("Enemy"));
           
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(bulletDamage);
            }

            // Destroy the bullet
            Destroy(gameObject);
        }
    }

}
