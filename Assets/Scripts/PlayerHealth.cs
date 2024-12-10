using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int lives = 3;

    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.CompareTag("EnemyBullet"))
    //     {
    //         lives--;
    //         Destroy(collision.gameObject);

    //         if (lives <= 0)
    //         {
    //             // Trigger game over
    //             Debug.Log("Game Over!");
    //         }
    //     }
    // }
}
