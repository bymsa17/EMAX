using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    public enum State { Default, Dead, God };
    public State state = State.Default;

    public int life;
    [Header("State")]
    public bool canMove = true;
    public bool canJump = true;
    public bool isFacingRight = true;
    public bool isJumping = false;
    public bool isRunning = false;
    [Header("Physics")]
    public Rigidbody2D rb;
    public Collisions collisions;
    [Header("Speed")]
    public float walkSpeed;
    public float runSpeed;
    public float movementSpeed;
    public float horizontalSpeed;
    public Vector2 axis;
    [Header("Forces")]
    public float jumpWalkForce;
    public float jumpRunForce;
    public float jumpForce;
    /*[Header("Ability")]
    public Transform boxTransform;
    public Vector2 boxPos;
    public Vector2 distance;
    public float speed;*/
    [Header("Graphics")]
    public SpriteRenderer rend;
    //[Header("Transforms")]
    //public Transform flipTransform;

    void Start()
    {
        collisions = GetComponent<Collisions>();
        rb = GetComponent<Rigidbody2D>();

        //collisions.MyStart();
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
                // TODO: DeadUpdate();
                break;
            case State.God:
                // TODO: GodUpdate();
                break;
            default:
                break;
        }
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

    protected virtual void DefaultUpdate()
    {
        //Calcula el movimiento en horizontal
        HorizontalMovement();
        //Saltar
    }

    void HorizontalMovement()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        if (!canMove || (-0.1f < axis.x && axis.x < 0.1f))
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            horizontalSpeed = 0;
            return;
        }

        if (collisions.isTouchingWall)
        {
            if ((isFacingRight && axis.x > 0.1f) || (!isFacingRight && axis.x < -0.1f))
            {
                horizontalSpeed = 0;
                return;
            }
        }

        if (isFacingRight && axis.x < -0.1f) Flip();
        if (!isFacingRight && axis.x > 0.1f) Flip();
        
        if (isRunning) movementSpeed = runSpeed;
        else movementSpeed = walkSpeed;

        horizontalSpeed = movementSpeed * axis.x;
    }

    void VerticalMovement()
    {
        /*
         * bool lookingUp
         * bool lookingDown
         * bool crouch
         */
    }

    void Jump()
    {
        isJumping = true;
    }

    void Flip()
    {
        rend.flipX = !rend.flipX;
        isFacingRight = !isFacingRight;
        collisions.Flip();
    }

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
                if (isRunning) jumpForce = jumpRunForce;
                else jumpForce = jumpWalkForce;
                Jump();
            }
        }

    }

    /*public void Ability(Collider other)
    {
        if(other.tag == "MetalBox")
        {
            if((transform.position.x + 5 >= boxTransform.position.x) && (transform.position.x < boxTransform.position.x))
            {
                boxPos.x = boxTransform.position.x + (distance.x * speed * Time.deltaTime);
            }
            else if((transform.position.x - 5 <= boxTransform.position.x) && (transform.position.x > boxTransform.position.x))
            {
                boxPos.x = boxTransform.position.x - (distance.x * speed * Time.deltaTime);
            }
            else if (player.transform.position.x == boxTransform.position.x)
            {
                
            }
        }
    }*/

    public void ReceiveDamage(int damge)
    {
        life -= damge;
        if(life <= 0)
        {
            life = 0;
            state = State.Dead;
        }
    }
    #endregion
}
