﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStopperFollowBullet : MonoBehaviour
{
    // Bullet speed
    float moveSpeed = 5.5f;

    // Referencese the bullet rigidbody
    Rigidbody2D rb2D;

    // References the player script
    PlayerController target;

    // Controls the direction which the bullet will move 
    Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<PlayerController>();
      
    }

    private void Update()
    {
        // THE BULLET FOLLOW'S PLAYER
        // Add direction to the bullet using player values if player is active
        if (target.gameObject.activeSelf)
        {
            moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        }

        // Add velocity to the bullet
        rb2D.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
        //THE BULLET FOLLOW'S PLAYER

    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (SceneController.cheat == false)
        {


            if (collision.CompareTag("Player"))
            {
                // Decrease player's life
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
        if (collision.CompareTag("Ground")  || collision.CompareTag("Elevator"))
        {
            Destroy(gameObject);
        }

        Destroy(gameObject, 5f);


    }


}