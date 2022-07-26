using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class TopDownMovementComponent : MonoBehaviour
{
    Rigidbody2D rb;
    float horizontalInput;
    float verticalInput;
    float moveLimiter = 0.7f;
    [SerializeField] private float movementSpeed = 8f;
    private bool PlayerDead = false;
    // Start is called before the first frame update
    void Start()
    {
        // initializing the rigidbody
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    // Update is called once per frame
    void Update()
    {
        // Getting the Player's input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Player Death
        if (PlayerDead)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        if (horizontalInput != 0 && verticalInput != 0)
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontalInput *= moveLimiter;
            verticalInput *= moveLimiter;
        }
        move();
    }

    private void FixedUpdate()
    {
        //moveAddForce();
    }

    public void DisableMovement()
    {
        rb.velocity = Vector2.zero;
        PlayerDead = true;
    }

    private void move()
    {
        // Directly sets the player's velocity based on input
        rb.velocity = new Vector2(horizontalInput * movementSpeed, verticalInput * movementSpeed);
    }

    private void moveAddForce()
    {
        rb.AddForce(new Vector2(horizontalInput * 100, verticalInput * 100));
    }
}
