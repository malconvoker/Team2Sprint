using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D rb;
    public LayerMask groundLayer;

    [Header("Collision")]
    public bool onGround = false;
    public float groundLine = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //Ground Check
        onGround = Physics2D.Raycast(transform.position, Vector2.down, groundLine,
            groundLayer);

        // inputs
        bool space = Input.GetKey(KeyCode.Space);
        bool rightKey = Input.GetKey(KeyCode.RightArrow);
        bool leftKey = Input.GetKey(KeyCode.LeftArrow);

        if (rightKey)
        {
            Debug.Log("Right key pressed");
            rb.AddForce(Vector2.right, ForceMode2D.Impulse);
        }

        if (leftKey)
        {
            Debug.Log("Left key pressed");
            rb.AddForce(Vector2.left, ForceMode2D.Impulse);
        }

        if (space && onGround)
        {
            Debug.Log("Space key pressed");
            rb.AddForce(Vector2.up*4, ForceMode2D.Impulse);
        }

    }
}
