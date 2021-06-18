using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStopperAI : MonoBehaviour
{
    // Transform
    [SerializeField]
    Transform player;

    // GameObject
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject boneDrop;

    // Float 
    [SerializeField]
    float bulletRange;
    [SerializeField]
    float fireRate;
    float nextFire;
    

    // Int
    private int spawnChance;
    int life = 5;

    // Start is called before the first frame update
    void Start()
    {
        nextFire = Time.time;
       
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfTimeToFire();
        spawnChance = Random.Range(0, 2);
    }

    // Controls when the enemy will attack(shoot)
    void CheckIfTimeToFire()
    {
        float disToPlayer = Vector2.Distance(transform.position, player.position);
        Vector3 pos;

        pos = new Vector3(transform.position.x , transform.position.y + 1.3f);

        if (Time.time > nextFire && disToPlayer < bulletRange)
        {
            if (this.gameObject.transform.position.y <= player.transform.position.y + 2)
            {
                SoundManager.PlaySound("enemiesShoot");
                // Shoots just when the diference between player and enemy Y position is between 0 and 5         
                Instantiate(bullet, pos, Quaternion.identity);
                nextFire = Time.time + fireRate;
            }

            if (player.transform.eulerAngles.y == 180)
            {
                //Ativar animação de tiro para a esquerda
                transform.eulerAngles = new Vector3(0, 180, 0);
                //Desativar animação de tiro para a esquerda
            }
            else
            {
                // Ativar animação de tiro para a direita
                transform.eulerAngles = new Vector3(0, 0, 0);
                // Desativar animação de tiro para a esquerda
            }

        }

        //Animação parado


    }

    //  Destroy the enemy when it collides with an object whith the tag Bullet
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //  Decrease the enemy life when it collides with an object that has the tag Bullet
        if (collision.gameObject.CompareTag("Bullet") && life >= 0)
        {
            // Animação levando dano
            SoundManager.PlaySound("enemiesDamage");
            life -= 1;
            Destroy(collision.gameObject);

            if (life == 0)
            {
                //Animação morrendo
                EndElevator.enemiesLength -= 1;
                Destroy(gameObject);

                if (spawnChance > 0)
                {
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
