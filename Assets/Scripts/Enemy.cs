using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 3; // Health of the enemy

    // Function to reduce health when hit
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject); // Destroy the enemy when health is 0
        }
    }



    // Detect collision with bullets
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            // Take damage when hit by a player bullet
            TakeDamage(1);

            // Destroy the bullet
            Destroy(collision.gameObject);
        }
    }
}
