﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    public enum State { Default, Dead, God };
    public State state = State.Default;

    //private Transform player;
    public int life;
    [Header("State")]
    public bool canMove = true;
    public bool canJump = true;
    public bool isFacingRight = true;
    public bool isJumping = false;
    public bool isRunning = false;
    public bool isLaddering = false;
    public bool isLookingUp = false;
    public bool isLookingDown = false;
    [Header("Physics")]
    public Rigidbody2D rb;
    public Collisions collisions;
    private float gravity;
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
    [Header("Ability")]
    public Collider2D abilityCollider;
    public ContactFilter2D filter;
    public Collider2D[] results;
    public int maxColliders = 2;
    public int numResults = 0;
    public float abilityForce = 5;
    public bool lostSpeed = false;
    //public bool doAbility = false;

    void Start()
    {
        collisions = GetComponent<Collisions>();
        rb = GetComponent<Rigidbody2D>();
        gravity = rb.gravityScale;

        //player = this.transform;

        //collisions.MyStart();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Default:
                DefaultUpdate();
                if (lostSpeed == true) LostSpeed();
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

        results = new Collider2D[maxColliders];
        numResults = Physics2D.OverlapCollider(abilityCollider, filter, results);

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

        //Escalerindando
        if (isLaddering)
        {
            VerticalMovement();
        }
    }

    protected virtual void DeadUpdate()
    {
        //Animation dead player
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
        if ((axis.y > 0.1f) || (axis.y < 0.1f))
         {
            this.transform.position += new Vector3(0, axis.y * 0.05f, 0);
         }
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
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;
        if (other.tag == "Ladder")
        {
            isLaddering = true;
            canJump = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        rb.gravityScale = gravity;
        if (other.tag == "Ladder")
        {
            isLaddering = false;
            canJump = true;
        }
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
    public void Ability()
    {
        //if(doAbility) return;

        //doAbility = true;
        if(numResults > 0)
        {
            Debug.Log("Ability");
            for(int i = 0; i < numResults; i++)
            {
                if(results[i].gameObject.tag == "MetalBox")
                {
                    Vector2 dir = results[i].transform.position - this.transform.position;
                    dir.Normalize();
                    results[i].GetComponent<Rigidbody2D>().AddForce(dir * abilityForce, ForceMode2D.Impulse);
                }
                else if(results[i].gameObject.tag == "WoodBox")
                {
                    Vector2 dir = results[i].transform.position - this.transform.position;
                    dir.Normalize();
                    results[i].gameObject.SetActive(false);
                }
            }
        }
    }

    public void ReceiveDamage(int damge)
    {
        life -= damge;
        if(life <= 0)
        {
            life = 0;
            state = State.Dead;
        }
    }

    public void LiquidPositive()
    {
        walkSpeed = 10;
        runSpeed = 14;
    }

    public void LostSpeed()
    {
        walkSpeed -= 0.1f;
        runSpeed -= 0.14f;

        if ((walkSpeed <= 5) || (runSpeed <= 7))
        {
            walkSpeed = 5;
            runSpeed = 7;
            lostSpeed = false;
        }
    }

    public void LiquidNegative()
    {
        walkSpeed = walkSpeed/2;
        runSpeed = runSpeed/2;
    }

    public void Reset()
    {
        life = 3;
        canMove = true;
        canJump = true;
        isFacingRight = true;
        isJumping = false;
        isRunning = false;
}

    #endregion
    #region Sets
    public void SetGod()
    {



        state = State.God;
    }
    #endregion

}
