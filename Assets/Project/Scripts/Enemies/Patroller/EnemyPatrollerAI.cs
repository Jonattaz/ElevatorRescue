using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyPatrollerAI : MonoBehaviour
{
    // Reference to waypoints
    public List<Transform> points;

    // The int value for next point index
    public int nextID = 0;

    // The value of that applies to ID for changing
    int idChangeValue = 1;

    // Speed of movement
    public float speed = 2;

    // Float
    [SerializeField]
    float fireRate;
    float nextFire;
    [SerializeField]
    float bulletRange;
    float disToPlayer;

    // Transform
    [SerializeField]
    Transform player;

    // GameObject
    [SerializeField]
    GameObject bulletRight;
    [SerializeField]
    GameObject bulletLeft;
    [SerializeField]
    GameObject boneDrop;

    // Int
    private int spawnChance;
    int life = 3;

    // Bool
    private bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        fireRate = 1.5f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        spawnChance = Random.Range(0, 2);
       
        if (canMove)
        {
            MoveToNextPoint();

        }

        CheckIfTimeToFire();
    }

    void MoveToNextPoint()
    {
        // Get the next point transform
        Transform goalPoint = points[nextID];

        // Flip the enemy transform to look into the point's direction
        if (goalPoint.transform.position.x > transform.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);

        // Move the enemy towards the goal point
        transform.position = Vector2.MoveTowards(transform.position,
            goalPoint.position, speed * Time.deltaTime);


        // Check the distance between enemy and goal point to trigger next point
        if (Vector2.Distance(transform.position, goalPoint.position) < 1f)
        {
            // Check if we are at the end of the line (make change -1)
            if (nextID == points.Count - 1)
                idChangeValue = -1;

            // Check if we are at the start of the line (make the change +1)
            if (nextID == 0)
                idChangeValue = 1;

            //Apply the change on the nextID
            nextID += idChangeValue;

        }
    }


    // Controls when the enemy will attack(shoot)
    void CheckIfTimeToFire()
    {
        disToPlayer = Vector2.Distance((transform.position), player.transform.position);
        Vector3 pos;
        pos = new Vector3(transform.position.x, transform.position.y + 1.2f);


        if (Time.time > nextFire && disToPlayer < bulletRange)
        {
            SoundManager.PlaySound("enemiesShoot");
            // Animação atirando ativa

            if(transform.localScale == new Vector3(-1, 1, 1)) 
                Instantiate(bulletRight, pos, Quaternion.identity);
            else
                Instantiate(bulletLeft, pos, Quaternion.identity);
            nextFire = Time.time + fireRate;
            // Animação atirando desativa
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Decrease one life point from the enemy if he collide with one object with the tag Bullet
        if (collision.gameObject.CompareTag("Bullet") && life >= 0)
        {
            SoundManager.PlaySound("enemiesDamage");
            life -= 1;
            //Animação levando dano
            Destroy(collision.gameObject);
            if (life == 0) 
            {
                //Animação morrendo
                EndElevator.enemiesLength -= 1;
                Destroy(gameObject);

                if (spawnChance > 0)
                {
                    Instantiate(boneDrop, transform.position, Quaternion.identity);
                }
            }

        }


        if (collision.gameObject.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canMove = false;
        }
        
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canMove = true;
        }
    }

















}
