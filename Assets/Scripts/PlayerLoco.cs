using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLoco : MonoBehaviour
{

    public Rigidbody2D rb;
    public Transform groundCheck;
    public Transform wallCheck;
    public Animator animator;

    public LayerMask groundLayer;
    public LayerMask wallLayer;
    public float jumpingPower = 8f;

    private float horizontal;
    private float speed = 8f;
    private bool isFacingRight = true;

    private bool isWallSliding;
    private float wallSlidingSpeed = 2f;

    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpTime = 0.2f;
    private float wallJumpCounter;
    private float wallJumpingDuration = 0.4f;

    [SerializeField]
    public Vector2 wallJumpPower = new Vector2(8f, 10f);



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.transform.position = new Vector2(0, 38);
    }


    void Update()
    {

        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }

        WallSlide();
        WallJump();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
            animator.SetBool("isJumping", true);
        }

        if (context.canceled && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
            animator.SetBool("isJumping", false);
        }

        
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }
    private void WallSlide() 
    {
        if (IsWalled() && !IsGrounded() && horizontal != 0f)
        {
            isWallSliding = true;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Clamp(rb.linearVelocity.y, -wallSlidingSpeed, float.MaxValue));
            animator.SetBool("isWallSliding", true);
        }
        
    }

    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            animator.SetBool("isWallSliding", false );
            wallJumpingDirection = -transform.localScale.x;
            wallJumpCounter = wallJumpTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && wallJumpCounter > 0f)
        {
            isWallJumping = true;
            rb.linearVelocity = new Vector2(wallJumpingDirection * wallJumpPower.x, wallJumpPower.y);
            wallJumpCounter = 0f;

            if (transform.localScale.x != wallJumpingDirection) //flip player when jumping 
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = Vector3.zero;
                localScale.x *= -1f;
                transform.localScale = localScale;

            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration); //no double wall jumps
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        //animator.SetFloat("Speed", Mathf.Abs(horizontal));
    }

}
