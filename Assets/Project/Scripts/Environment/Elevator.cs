using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    // Float that represent the elevator speed
    float moveSpeed = 3f;

    // Bool that when is true mean that the elevator is working
    bool moveUp = true;

    // Where the elevator is going
    public Transform destination;

    // Start point
    public Transform startPoint;

    
    // Update is called once per frame
    void Update()
    {
        Move();
    }


    // Controls the elevator movement
    void Move()
    {
        if (transform.position.y >= destination.position.y)
        {
            moveUp = false;
        }
        if(transform.position.y <= startPoint.position.y)
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
