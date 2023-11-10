using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveBackAndForth : MonoBehaviour
{
    [Tooltip("Initially moving left or down, this reverses it")]
    [SerializeField] private bool movingReverse = false;
    [Tooltip("Moving horizontally or vertically")]
    [SerializeField] private bool movingVertically = false;
    [SerializeField] private float moveSpeed = 2f;
    [Tooltip("Time to wait at turn point")]
    [SerializeField] private float waitTime = 0f;
    private float waitTimer = 0f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if not waiting
        if (waitTimer <= 0f)
        {
            rb.velocity = movingVertically ?
                movingReverse ? (Vector2.up * moveSpeed) : (Vector2.down * moveSpeed)
                :
                movingReverse ? (Vector2.right * moveSpeed) : (Vector2.left * moveSpeed);
        }
        else
        {
            waitTimer -= Time.deltaTime;
        }
    }

    public void TurnAround(float waitMult)
    {
        // flip direction and wait
        movingReverse = !movingReverse;
        rb.velocity = Vector2.zero;
        waitTimer = waitTime * waitMult;
    }
}
