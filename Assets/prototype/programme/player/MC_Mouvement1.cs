using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class MC_Mouvement1 : MonoBehaviour
{
    public bool isFacingRight { get => _isFacingRight; }

    private MC_input Minput;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float avarageSpeed = 5f;
    [SerializeField] private float acceleration = 10f;

    [SerializeField] private float runSpeed = 8f;
    private bool isRunning = false;

    private bool isGrounded;
    [SerializeField] private float jumpForce = 5f;
    private int jumpCount = 0;
    [SerializeField] private int maxJump = 0;

    private Rigidbody2D rb;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask leSol;

    bool _isFacingRight = true;

    float fallMultiplier = 2.5f;
    float lowJumpMultiplier = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Minput = GetComponent<MC_input>();
    }

    void FixedUpdate()
    {
        
        Move();
        Flip();
        Grounded();
        Jump();
        
    }

    private void Move()
    {
        if (Minput.inputRun && !isRunning)
        {
            speed = runSpeed;
        }
        else
        {

            speed = avarageSpeed;
        }

        Vector2 force = new Vector2(Minput.inputHorizontal.x * speed * acceleration, 0);
        rb.AddForce(force, ForceMode2D.Force);

        float maxSpeed = speed;
        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        }
        if (Mathf.Abs(Minput.inputHorizontal.x) < 0.01f)
        {
            
            rb.velocity = new Vector2(rb.velocity.x * 0.2f, rb.velocity.y);

        }

    }
    private void Grounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, leSol);
        if (isGrounded)
        {
            jumpCount = 0;
        }

    }

    private void Flip()
    {
        float move = Minput.inputHorizontal.x;
        if ((move > 0 && !_isFacingRight) || (move < 0 && _isFacingRight))
        {
            _isFacingRight = !_isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

        }
        
    }
    private void Jump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        if (Minput.inputJump && isGrounded)
        {

            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpCount++;


        }
        else if (Minput.inputJump && jumpCount < maxJump && !isGrounded)
        {
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpCount++;

        }
    }

}
