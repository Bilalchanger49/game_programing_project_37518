using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            
            Destroy(gameObject);

            // Optional: Destroy the enemy
            Destroy(collision.gameObject);

            // Log the collision for debugging
            GameManager.Instance.GameOver();
        }
    }
    // Movement variables
    public float maxSpeed = 3f;
    public float playerBoundaryRadius = 0.5f;

    // Bullet variables
    public GameObject playerBulletPrefab; // Drag and drop PlayerBullet prefab here
    public GameObject playerBulletPosition01; // Drag and drop first bullet spawn position here
    public GameObject playerBulletPosition02; // Drag and drop second bullet spawn position here

    // Update is called once per frame
    void Update()
    {
        // Position and movement logic
        Vector2 pos = transform.position; // Convert current position to Vector2
        pos.y += Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime;

        // Horizontal movement
        pos.x += Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime;

        // Boundary checks
        if (pos.y + playerBoundaryRadius > Camera.main.orthographicSize)
        {
            pos.y = Camera.main.orthographicSize - playerBoundaryRadius;
        }
        if (pos.y - playerBoundaryRadius < -Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize + playerBoundaryRadius;
        }
        if (pos.x + playerBoundaryRadius > Camera.main.aspect * Camera.main.orthographicSize)
        {
            pos.x = Camera.main.aspect * Camera.main.orthographicSize - playerBoundaryRadius;
        }
        if (pos.x - playerBoundaryRadius < -Camera.main.aspect * Camera.main.orthographicSize)
        {
            pos.x = -Camera.main.aspect * Camera.main.orthographicSize + playerBoundaryRadius;
        }

        // Apply updated position
        transform.position = new Vector3(pos.x, pos.y, transform.position.z); // Convert pos back to Vector3

        // Shooting bullets
        if (Input.GetKeyDown("space"))
        {
            ShootBullets();
        }
    }

    // Function to shoot bullets
    void ShootBullets()
    {
        // Spawn bullet at position 1
        GameObject bullet01 = Instantiate(playerBulletPrefab);
        bullet01.transform.position = playerBulletPosition01.transform.position;

        // Spawn bullet at position 2
        GameObject bullet02 = Instantiate(playerBulletPrefab);
        bullet02.transform.position = playerBulletPosition02.transform.position;
    }
}
