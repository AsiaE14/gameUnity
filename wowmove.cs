using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class wowmove : MonoBehaviour
{

    private float horizontal;
    public float speed;
    public float jumpingPower ;
    private bool isFacingRight = true;

    public float countJ;
    private float ccc;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Update()
    {
      
   
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            ccc = countJ;
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (Input.GetKeyDown(KeyCode.Space) && ccc > 0)
        {
            ccc -= 1;
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }



        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position,1, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
