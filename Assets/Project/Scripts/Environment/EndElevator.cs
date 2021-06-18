using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndElevator : MonoBehaviour
{

    // Float
    float moveSpeed = 3f;

    // Bool
    bool moveUp = true;

    //Sprite renderer
    public SpriteRenderer actualRoof;

    // New roof sprite, is activated when all enemies are dead 
    public Sprite newRoof;

    public GameObject elevatorLight;

    // Transform
    public Transform destination;
    public Transform startPoint;

    // GameObject
    public GameObject[] enemies;
    
    //Int
    public static int enemiesLength;

    // Start is called before the first frame update
    void Start()
    {
        enemiesLength = enemies.Length;
    }

    // Update is called once per frame
    void Update()
    {
        // Activate the elevator when all enemies are defeated
        if (enemiesLength <= 0)
        {
            elevatorLight.SetActive(false);
            SoundManager.PlaySound("elevadorOn");
            actualRoof.gameObject.transform.localScale = new Vector3(1f, 1f, 0);
            actualRoof.sprite = newRoof;
            Move();
        }

    }


    // Controls the elevator movement
    void Move()
    {
        if (transform.position.y >= destination.position.y)
        {
            moveUp = false;
        }
        if (transform.position.y <= startPoint.position.y)
        {
            moveUp = true;
        }

        if (moveUp)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }

    }
}
