using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    public enum State { Default, Dead, God };
    public State state;

    [Header("State")]
    public bool canMove = true;
    public bool canJump = true;
    public bool running = false;
    public bool isFacingRight = false;
    public bool isJumping = false;

    [Header("Physics")]
    public Rigidbody2D rb;
    public Collisions collisions;

    [Header("Speeed properties")]
    public float walkSpeed = 2;
    public float runSpeed = 3;
    public float movementSpeed;

    [Header("Force properties")]
    public float jumpWalkForce;
    public float jumpRunForce;
    public float jumpForce;

    [Header("Movement")]
    public Vector2 axis;
    public float horizontalSpeed;

    //[Header("Transforms")]
    //public Transform flipTransform;

    [Header("Graphics")]
    public SpriteRenderer rend;

    void Start()
    {
        collisions = GetComponent<Collisions>();
        rb = GetComponent<Rigidbody2D>();

        collisions.MyStart();

        isFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Default:
                DefaultUpdate();
                break;
            case State.Dead:
                break;
            case State.God:
                break;
            default:
                break;
        }
    }

    void DefaultUpdate()
    {
        //Calcula el movimiento en horizontal
        HorizontalMovement();
        //Saltar
    }

    private void FixedUpdate()
    {
        collisions.MyFixedUpdate();

        if (isJumping)
        {
            isJumping = false;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        //Aplicaremos el movimiento
        rb.velocity = new Vector2(horizontalSpeed, rb.velocity.y);
    }

    void HorizontalMovement()
    {
        if (!canMove)
        {
            horizontalSpeed = 0;
            return;
        }

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        if (-0.1f < axis.x && axis.x < 0.1f)
        {
            horizontalSpeed = 0;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            return;
        }

        /*if (collisions.isTouchingWall)
        {
            if ((isFacingRight && axis.x > 0.1f) || (!isFacingRight && axis.x < -0.1f))
            {
                horizontalSpeed = 0;
                return;
            }
        }

        if (isFacingRight && axis.x < -0.1f) Flip();
        if (!isFacingRight && axis.x > 0.1f) Flip();
        */
        if (running) movementSpeed = runSpeed;
        else movementSpeed = walkSpeed;

        horizontalSpeed = axis.x * movementSpeed;
    }

    void VerticalMovement()
    {
        /*
         * bool lookingUp
         * bool lookingDown
         * bool crouch
         */
    }

    void Jump(float force)
    {
        jumpForce = force;
        isJumping = true;
    }

    /*void Flip()
    {
        rend.flipX = !rend.flipX;
        isFacingRight = !isFacingRight;
        collisions.Flip(isFacingRight);
    }*/

    #region Public functions
    public void SetAxis(Vector2 inputAxis)
    {
        axis = inputAxis;
    }
    public void JumpStart()
    {
        if (!canJump) return;

        if (state == State.Default)
        {
            if (collisions.isGrounded)
            {
                if (running) Jump(jumpRunForce);
                else Jump(jumpWalkForce);
            }
        }

    }
    public void Damage(int hit)
    {

    }
    #endregion
}
