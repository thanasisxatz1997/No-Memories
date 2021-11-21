using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMain : MonoBehaviour
{

    private float movementInputDirection;

    public float movementSpeed=10.0f;
    public float jumpForce = 16.0f;

    private bool isFacingRight=true;
    private bool isWalking;

    private Rigidbody2D rb;
    private Animator anim;

    void Start()// Start is called before the first frame update
    {
        rb = GetComponent<Rigidbody2D>(); //store a reference to the rigid body on the player 
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();//Checks for input every frame
        CheckMovementDirection();
        UpdateAnimations();
    }
    private void FixedUpdate()
    {
        ApplyMovement();//Calls Apply movement function to apply movement
        //CheckSurroundings();//Calls checkSurroundings
    }

    private void CheckInput() // this function will get called to check for any kind of input we might expect from the player
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal"); //horizontal is referenced to the A and D keys by default Raw makes it always return 0 or 1, without raw it would return a float between 0 and 1 the longer you hold the higher the number
        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void CheckMovementDirection()
    {
        if(isFacingRight && movementInputDirection<0)
        {
            Flip();
        }
        else if(!isFacingRight && movementInputDirection>0)
        {
            Flip();
        }

        if(rb.velocity.x!=0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }

    private void UpdateAnimations()
    {
        anim.SetBool("isWalking", isWalking);
    }

    private void ApplyMovement()
    {
        rb.velocity = new Vector2(movementSpeed * movementInputDirection, rb.velocity.y);
        
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

}
