using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollerBulletRight : MonoBehaviour
{
    // Bullet speed
    float moveSpeed = 25f;

    // Referencese the bullet rigidbody
    Rigidbody2D rb2D;

    // References the player script
    PlayerController target;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<PlayerController>();

        // Add velocity and direction to the bullet
        rb2D.velocity = transform.right * moveSpeed;
        Destroy(gameObject, 3f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneController.cheat == false)
        {
            if (collision.CompareTag("Player"))
            {
                // Decrease the player's life
                HeartSystem.life -= 1;

                // Destroy the bullet
                Destroy(gameObject);

                // If the bullet hit the player in his last life
                if (HeartSystem.life == 0)
                {
                    target.gameObject.SetActive(false);
                    HeartSystem.life = 0;
                }
            }

        }
        if (collision.CompareTag("Player"))
        Destroy(gameObject);
        

        // Destroy the bullet if collide with the ground or elevator
        if (collision.CompareTag("Ground") || collision.CompareTag("Elevator"))
        {
            Destroy(gameObject);
        }

        Destroy(gameObject, 5f);


    }


}
