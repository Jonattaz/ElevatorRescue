using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// esse aq virou o script geral do boss
public class EnemyFollowPlayer : MonoBehaviour
{
    
    // variaveis relacionadas a mecanica de movimentação e tiro
    public float speed;
    public float shootingRange;
    public float fireRate = 0.8f;
    private float nextFireTime;
    public Transform player;

    // Referência o  hability script
    public HabilityScript habilityScript;


    // variaveis relacionadas a HealthBar
    public int maxHealth = 500;
    public int currentHealth;
    public HealthBarScript healthBar;

    // Variaveis relacionadas ao jump do boss
    private Rigidbody2D rb;

    //tiro
    public GameObject bullet;

    //spawn do tiro
    public GameObject bulletParent;

    //animação
    public Animator Animator;
    private bool andnado;

    void Start()
    {
        habilityScript = GetComponent<HabilityScript>();

        player = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        // Tiro vai para direção do game object com tag de "Player"
        // Serve para referenciar o transform do objeto que possui a tag player
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;

        //chamando a função do script "HealthBarScript"
        healthBar.SetMaxHealth(maxHealth);

        
    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        //anda até o player se o mesmo estiver fora do alcance do boss
        if (distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            Animator.SetBool("andnado", true);

            if (transform.position.x <= player.position.x)
            {
                //Animação boss para a esquerda
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if(transform.position.x > player.position.x)
            {
                //Animação boss para a direita
                transform.eulerAngles = new Vector3(0, 180, 0);
            }

        }
        //para e começa a atirar se o player estiver dentro do alcance do boss
        else if (distanceFromPlayer <= shootingRange && nextFireTime <Time.time)
        {
            Animator.SetTrigger("titiro");
            if (transform.position.x <= player.position.x)
            {
                //Animação boss para a esquerda
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (transform.position.x > player.position.x)
            {
                //Animação boss para a direita
                transform.eulerAngles = new Vector3(0, 180, 0);
             }


            SoundManager.PlaySound("bossShoot");
            //Animação de tiro normal
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }


        if (currentHealth <= maxHealth / 2)
        {
            habilityScript.enabled = true;
        }


        if (currentHealth == 0)
        {
            //Animação da morte do boss
            Destroy(this.gameObject);
        }
        
    }

    private void OnDrawGizmosSelected()
    {   
        //área de ataque do boss
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }

    //função para contar o dano
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //chama a função do script "HealthBarScript"
        healthBar.SetHealth(currentHealth);
    }


    /* OnTriggerEnter2D é um método que quando um objeto trigger entre em contato com outro,
     * não precisa ser trigger, você pode adicionar uma ação, 
     * no caso do código eu usei um if para caso o outro objeto(collision.gameObject.CompareTag("Bullet")) 
     * entre em contato com o boss é chamado o TakeDamage 
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            TakeDamage(1);
            SoundManager.PlaySound("enemiesDamage");
        }

      
            // Faz o boss pular caso colida com um objeto trigger da tag Obstacle
            switch (collision.tag)
            {
                case "Obstacle":
                    rb.AddForce(Vector2.up * 100000f);
                    break;
             
            }
      
            
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        // Verifies if the boss object is active in the scene
        if (this.gameObject.activeSelf)
        {
            // If the player is active he's able to became a child object of the object who has the tag Elevator
            if (col.gameObject.CompareTag("Ground"))
            {
                gameObject.transform.SetParent(col.gameObject.transform, true);
            }

        }
    }





}

