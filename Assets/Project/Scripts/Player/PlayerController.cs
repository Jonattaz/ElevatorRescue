using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // RigidBody
    Rigidbody2D rb2d;

    // Float
    [SerializeField]
    float moveSpeed;
    public float checkRadius;
    private float jumpForce;
    private float jumpTimeCounter;
    public float jumpTime;

    // Bool
    bool isGrounded;
    private bool isJumping;
    private bool andando;

    // Transform
    public Transform feetPos;

    // LayerMask
    public LayerMask whatIsGround;

    
    // Animator
    public Animator Animator;

    
    
    // Start is called before the first frame update
    void Start()
    {
        jumpForce = 12f;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

     
        // Call the movement method
        Movement();

        // Call the Jump method
        Jump();
        

    }


    // This method controls the player's movement
    private void Movement()
    {
        
        // When the right arrow is presse the player's move to the right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Cause the flip movement when player change sides
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.position += transform.right * (Time.deltaTime * moveSpeed);
            Animator.SetBool("andando", true);
        }

        // When the left arrow is presse the player's move to the left
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Cause the flip movement when player change sides
            transform.eulerAngles = new Vector3(0, 180, 0);
            transform.position += transform.right * (Time.deltaTime * moveSpeed);
            Animator.SetBool("andando", true);
        }
        else{
            Animator.SetBool("andando", false);
        }
      
    }


    // Control's the jump of the player
    private void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        // If isGrounded is true and the space key is pressed the jump action happens
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb2d.velocity = Vector2.up * jumpForce;

            Animator.SetBool("isJumping", true );

        }

        // If the player continues pressing space he can use a mini dash in the air
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb2d.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        // When the space is not being pressed isJumping is false
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
            Animator.SetBool("isJumping", false);
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        // Verifies if the player object is active in the scene
        if (this.gameObject.activeSelf)
        {
            // If the player is active he's able to became a child object of the object who has the tag Elevator
            if (col.gameObject.CompareTag("Elevator")) {
                gameObject.transform.SetParent(col.gameObject.transform, true);
            }

        }
    }


    void OnCollisionExit2D(Collision2D col)
    {
        // Verifies if the player object is active in the scene
        if (this.gameObject.activeSelf)
        {
            // if the player is active he's able to stop being a child of the object who has the tag Elevator
            if (col.gameObject.CompareTag("Elevator")) {

                gameObject.transform.parent = null;
            }

        }
    }

}


















