using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;
    [SerializeField] private float wallJumpPower = 4f;
    private bool isFacingRight = true;
    [Header("Mandatory fields")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform[] wallCheck = new Transform[2];
    [SerializeField] private LayerMask groundLayer;

   

    
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        // Prevent player from moving into a wall and sticking to it
        if (IsFacingWall() && !IsGrounded())
        {
            if (isFacingRight && horizontal > 0)
            {
                horizontal = 0;
            }
            if (!isFacingRight && horizontal < 0)
            {
                horizontal = 0;
            }
        }

        // Jump
        if (Input.GetButtonDown("Jump") && (IsGrounded() || IsFacingWall()) )
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        // Reduce upwards velocity if letting go of jump key
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2 (horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private bool IsFacingWall()
    {
        return Physics2D.OverlapArea(wallCheck[0].position, wallCheck[1].position, groundLayer);
    }

    private void Flip()
    {
        // Use localScale negation to flip character visually
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) 
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
