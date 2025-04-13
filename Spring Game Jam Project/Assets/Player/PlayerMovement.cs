using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private bool facingRight = true;

    [SerializeField] private float jumpSpeed;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if (facingRight && horizontal < 0f || !facingRight && horizontal > 0f)
        {
           facingRight = !facingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool IsGrounded()
    {
        Debug.Log(Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer));
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        
    }

    private void Jump()
    {

    }
}
