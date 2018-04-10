using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    public enum State { Default, Dead, God };
    public State state = State.Default;

    public bool isGod = false;
    public BoxCollider2D boxCollider;

    public Animator anim;
    private AudioPlayer audioPlayer;
    public float lowVolume;

    //private Transform position;
    public Vector3 testPos;
    public int score;
    public int life;
    public int damage = 1;

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
    public bool lostSpeed = false;
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
    public float timeCounter;
    //public bool doAbility = false;
    [Header("Canvas")]
    public GameObject canvasPause;
    public GameObject canvasGameplay;

    void Start()
    {
        collisions = GetComponent<Collisions>();
        rb = GetComponent<Rigidbody2D>();
        gravity = rb.gravityScale;

        boxCollider = GetComponent<BoxCollider2D>();

        timeCounter = 500;

        audioPlayer = GetComponentInChildren<AudioPlayer>();
        audioPlayer.PlayMusic(0);

        GameData.LoadGame(1);

        score = GameData.gameState.score;
        testPos = new Vector3(GameData.gameState.posX, GameData.gameState.posY, 0 );
        transform.position = testPos;

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
                timeCounter--;
                break;
            case State.Dead:
                DeadUpdate();
                break;
            case State.God:
                GodUpdate();
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
            anim.SetBool("isGrounded", collisions.isGrounded);
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

        anim.SetBool("isGrounded", collisions.isGrounded);
        anim.SetFloat("speedX", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("speedY", rb.velocity.y);
    }

    protected virtual void DeadUpdate()
    {
        horizontalSpeed = 0;
        //Animation dead player
    }

    protected virtual void GodUpdate()
    {
        //Input get axis x 
        //Input get axis y
        this.transform.position += new Vector3(axis.x * 0.1f, axis.y * 0.1f, 0);
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

        if(isRunning)
        {
            movementSpeed = runSpeed;
            anim.SetBool("run", true);
        }
        else
        {
            movementSpeed = walkSpeed;
            anim.SetBool("run", false);
        }
       
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

    public void Pause()
    {
        if(canvasPause.activeInHierarchy == false)
        {
            canvasPause.SetActive(true);
            canvasGameplay.SetActive(false);
            //LowVolume();
            Time.timeScale = 0;
            //AudioManager.SetMasterVolume(lowVolume);
            //audioPlayer.StopMusic();
            audioPlayer.PlayMusic(1);
        }
        else
        {
            canvasPause.SetActive(false);
            canvasGameplay.SetActive(true);
            Time.timeScale = 1;
            //audioPlayer.StopMusic();
            audioPlayer.PlayMusic(0);
        }
    }

    public void LowVolume()
    {
        lowVolume -= 1;
        if(lowVolume >= -10) lowVolume = -10;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ladder")
        {
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
            isLaddering = true;
            canJump = false;
            anim.SetBool("isGrounded", collisions.isGrounded);
            //audioPlayer.PlaySFX(1, 1, Random.Range(0.9f, 1.1f));
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ladder")
        {
            rb.gravityScale = gravity;
            isLaddering = false;
            canJump = true;
        }
    }

    public void OnParticleCollision(GameObject other)
    {
        if(other.gameObject.layer == 13)
        {
            //other.GetComponent<PlayerBehaviour>().ReceiveDamage();
            Debug.Log("CollisionHazard");
            ReceiveDamage();
        }
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 13)
        {
            Debug.Log("CollisionHazard");
            ReceiveDamage();
        }
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
        if(timeCounter <= 0)
        {
            //if(doAbility) return;
            if(numResults > 0)
            {
                Debug.Log("Ability");
                //doAbility = true;
                anim.SetBool("ability", true);
                //audioPlayer.PlaySFX(3, 1, Random.Range(0.9f, 1.1f));
                for(int i = 0; i < numResults; i++)
                {
                    if(results[i].gameObject.tag == "MetalBox")
                    {
                        Vector2 dir = results[i].transform.position - this.transform.position;
                        dir.Normalize();
                        results[i].GetComponent<Rigidbody2D>().AddForce(dir * abilityForce, ForceMode2D.Impulse);
                        audioPlayer.PlaySFX(2, 1, Random.Range(0.9f, 1.1f));

                    }
                    else if(results[i].gameObject.tag == "WoodBox")
                    {
                        Vector2 dir = results[i].transform.position - this.transform.position;
                        dir.Normalize();
                        results[i].gameObject.SetActive(false);
                        audioPlayer.PlaySFX(0, 1, Random.Range(0.9f, 1.1f));
                    }
                }
                timeCounter = 500;
            }
            //anim.SetBool("ability", doAbility);
        }
    }

    public void ReceiveDamage()
    {
        life -= damage;
        anim.SetBool("damage", true);
       

        if (life <= 0)
        {
            life = 0;
			anim.SetBool("dead", true);
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
        //position = GameData.gameState.position;
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
        isGod = !isGod;

        if (isGod)
        {
            state = State.God;
            horizontalSpeed = 0;
            rb.gravityScale = 0;
            rb.bodyType = RigidbodyType2D.Kinematic;
            boxCollider.enabled = false;
            rb.velocity *= 0;
        }
        else
        {
            state = State.Default;
            rb.gravityScale = gravity;
            rb.bodyType = RigidbodyType2D.Dynamic;
            boxCollider.enabled = true;
        }
    }
    #endregion

}
