using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 5f; //units/s
    [SerializeField] private float jumpForce = 5f;
    [Tooltip("Distance from object center to the point to check ground collision at")]
    [SerializeField] private float groundCheckOffset;

    private Vector3 newPosition;
    private Vector2 movement;
    private Animator animator;
    private Rigidbody2D rb;
    private bool grounded;
    private float horizontalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        newPosition = new Vector3(0f, 0f, 0f);
        movement = new Vector2(0f, 0f);
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // get inputs, save in movement vector
        movement.Set(Input.GetAxisRaw("Horizontal"), 0);

        // detect if standing on a platform
        RaycastHit2D hit = Physics2D.Raycast(
            new Vector2(transform.position.x, transform.position.y - Mathf.Abs(groundCheckOffset)), Vector2.down, 0.01f);
        // if on Platform and up key is pressed
        if (hit.collider != null)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        if (Input.GetAxisRaw("Vertical") > 0 && rb.velocity.y == 0 && grounded) //pressing up, not moving vertically, on platform
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); //jump
            animator.SetInteger("state", 2); //jumping animation
        }

        movement = Vector2.ClampMagnitude(movement, speed * Time.deltaTime);

        horizontalSpeed = movement.x;

        //set newPosition to be a combination of current position and movement vectors
        newPosition.Set(transform.position.x + movement.x, transform.position.y + movement.y, 0);

        //update position
        transform.position = newPosition;
        transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
