using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStalkerAI : MonoBehaviour
{
    // Transform
    [SerializeField]
    Transform player;

    // Float
    [SerializeField]
    float bulletRange;
    [SerializeField]
    float fireRate;
    float nextFire;
    float disToPlayer;
    [SerializeField]
    float agroRange;
    [SerializeField]
    float moveSpeed;

    //bools
    private bool IsWalking;

    //animator
    public Animator Animator;
    
  
    // GameObject
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject boneDrop;

    // Rigidbody
    Rigidbody2D rb2d;

    // Int
    private int spawnChance;
    int life = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        fireRate = 2.5f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfTimeToFire();
        spawnChance = UnityEngine.Random.Range(0, 2);

        // Distance to player
        disToPlayer = Vector2.Distance(transform.position, player.position);

        if (disToPlayer < agroRange)
        {
            // Chase player
            // Ativar animação de corrida
            //Animator.SetBool("IsWalking", true);
            ChasePlayer();
        }
        else
        {
            // Stop chasing player
            //Desativar animação de corrida
            //Animator.SetBool("IsWalking", false);
            StopChasingPlayer();
        }

    }

    void StopChasingPlayer()
    {
        Animator.SetBool("IsWalking", false);
        rb2d.velocity = new Vector2(0, 0);

    }

    void ChasePlayer()
    {
        Animator.SetBool("IsWalking", true);

        if (transform.position.x < player.position.x)
        {
            // Enemy is to the left side of the player, so move right
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(0.45f, 0.45f);


        }
        else
        {
            // Enemy is to the right side of the player, so move left
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-0.45f, 0.45f);

        }
    }

    // Controls when the enemy will attack(shoot)
    void CheckIfTimeToFire()
    {
        //float disToPlayer = Vector2.Distance(transform.position, player.position);
        float disToPlayer = Vector2.Distance(transform.position, player.position);
        Vector3 pos;

        pos = new Vector3(transform.position.x, transform.position.y + 2f);

        if (Time.time > nextFire && disToPlayer < bulletRange)
        {
            SoundManager.PlaySound("enemiesShoot");
            Animator.SetTrigger("tiro");
            // Animação atirando ou animação esfaqueando?
            Instantiate(bullet, pos , Quaternion.identity);
            nextFire = Time.time + fireRate;
            // Desativar animação
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //  Decrease the enemy life when it collides with an object that has the tag Bullet
        if (collision.gameObject.CompareTag("Bullet") && life >= 0)
        {

            SoundManager.PlaySound("enemiesDamage");
            life -= 1;
            Destroy(collision.gameObject);

            if (life == 0)
            {
                EndElevator.enemiesLength -= 1;
                Destroy(gameObject);

                if (spawnChance > 0)
                {
                    Instantiate(boneDrop, transform.position, Quaternion.identity);
                    Instantiate(boneDrop, transform.position, Quaternion.identity);
                    Instantiate(boneDrop, transform.position, Quaternion.identity);
                    Instantiate(boneDrop, transform.position, Quaternion.identity);
                }

            }

        }

        if (collision.gameObject.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }

    }

}













