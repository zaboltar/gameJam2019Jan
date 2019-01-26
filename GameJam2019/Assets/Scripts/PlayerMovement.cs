using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public Vector3 target; // The point user picks for the character to follow
    public bool facingRight = false; // Check where the character is facing
    private int move = 0; // Movement direction
    private float maxSpeed = 5f; // Speed of character movement
    private Animator anim; // Reference to the animator
    public Rigidbody2D lebody;

    // Use this for initialization
    void Start()
    {
        //anim = GetComponent<Animator>();
        lebody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Obtaining target point user clicked on screen
        if (Input.GetMouseButton(0))
        {
            // After user has clicked left mouse button recording mouse position
            Vector3 mousePos = Input.mousePosition;
            // Converting mouse position into coordinate system connected to the camera.
            target = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 1f));

            // Set movement direction depending on target point
            if (target.x < transform.position.x)
                move = -1;
            else if (target.x > transform.position.x)
                move = 1;
            Debug.Log(move);
        }

        // Flip the character if nessessary
        if (move == 1 && !facingRight)
            Flip();
        if (move == -1 && facingRight)
            Flip();

        // check if arrived to target point
        if (Mathf.Abs(target.x - transform.position.x) < 0.2f)
        {
            move = 0;
        }

        //anim.SetInteger("Movement", Mathf.Abs(move));

        // apply velocity to actually make character move

        lebody.velocity = new Vector2(move * maxSpeed, lebody.velocity.y);


    }


    void Flip()
    {
        Debug.Log("In Flip");
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


}
