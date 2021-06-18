using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    
    public Transform player;
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;
    Vector2 moveDir;
    void Start()
    {
        
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");

        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Direção do tiro
        moveDir = (target.transform.position - transform.position).normalized * speed;


        // Velocidade do tiro
        if (moveDir.x >= 0)
        {
            bulletRB.velocity = transform.right * speed;
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);

        }
        else
        {
            bulletRB.velocity = -transform.right * speed;
            transform.localScale = new Vector2(-transform.localScale.x,transform.localScale.y);

        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }


        if (SceneController.cheat == false)
        {
            if (collision.gameObject.CompareTag("Player") && collision.gameObject.activeInHierarchy)
            {
                HeartSystem.life -= 1;
                Destroy(gameObject);

                if (HeartSystem.life == 0)
                {
                    player.gameObject.SetActive(false);
                    HeartSystem.life = 0;
                }
            }

        }
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.activeInHierarchy)
            Destroy(gameObject);

    }
}
