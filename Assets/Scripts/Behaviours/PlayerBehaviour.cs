using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour {

    public enum State { Default, Dead, God };
    public State state = State.Default;

    public bool isGod = false;
    public BoxCollider2D boxCollider;

    public Animator anim;
    public Animator animHUD;
    public Animator animHUDPiece;
    public Animator animHeart1;
    public Animator animHeart2;
    public Animator animHeart3;
    private AudioPlayer audioPlayer;
    public float lowVolume;

    //private Transform position;
    public Vector3 testPos;
    public float timeCounter;
    public float coolDown = 3;
    public int life;
    public int damage = 1;
    [Header("Score")]
    public float scoreTime;
    public int scoreAbility = 300;
    public int scoreLife = 225;
    public int scorePiece;
    public bool takePiece;
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
    public float abilityCounter;
    public int useAbility;
    //public bool doAbility = false;
    [Header("Canvas")]
    public GameObject canvasPause;
    public GameObject canvasGameplay;

    [Header("Pause")]
    public Rail shadow;
    public PieceBehaviour piece;
    public PatrolBehaviour platform01;
    public PatrolBehaviour platform02;
    public PatrolBehaviour platform03;
    public PatrolBehaviour platform04;
    public GearBehaviour gear;
    public BalanceBehaviour balance;
    public Animator elevator;
    public DoorElevatorBehaviour doorElevator;

    void Start()
    {
        collisions = GetComponent<Collisions>();
        rb = GetComponent<Rigidbody2D>();
        gravity = rb.gravityScale;

        boxCollider = GetComponent<BoxCollider2D>();

        abilityCounter = 400;

        audioPlayer = GetComponentInChildren<AudioPlayer>();
        audioPlayer.PlayMusic(0);

        scoreTime = 325;
        scoreAbility = 300;
        scoreLife = 225;
    
        GameData.LoadGame(1);
    
        //testPos = new Vector3(GameData.gameState.posX, GameData.gameState.posY, 0 );
        //transform.position = testPos;

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
                abilityCounter--;
                coolDown -= Time.deltaTime;
                timeCounter += Time.deltaTime;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                if(timeCounter >= 60) scoreTime -= Time.deltaTime;
                if(takePiece == true) scorePiece = 150;
                else scorePiece = 0;
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
            audioPlayer.PlaySFX(26, 1, Random.Range(0.9f, 1.1f));
        }

        if(abilityCounter <= 0)
        {
            animHUD.SetBool("Active", true);
            //audioPlayer.PlaySFX(6, 1, Random.Range(0.9f, 1.1f));
        }
        if(abilityCounter == 0)
        {
            audioPlayer.PlaySFX(6, 1, Random.Range(0.9f, 1.1f));
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
            if(axis.y != 0) anim.SetBool("isClimbing", isLaddering);
        }

        anim.SetBool("isGrounded", collisions.isGrounded);
        anim.SetFloat("speedX", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("speedY", rb.velocity.y);
    }

    protected virtual void DeadUpdate()
    {
        horizontalSpeed = 0;
        GameData.SaveGame(1);
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
        else
        {
            anim.SetBool("climb", false);
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
            //canvasGameplay.SetActive(false);
            canvasGameplay.GetComponent<HideMouse>().enabled = false;
            audioPlayer.PlaySFX(23, 1, Random.Range(0.9f, 1.1f));
            //LowVolume();
            //Time.timeScale = 0;
            canMove = false;
            canJump = false;
            animHUD.enabled = false;
            animHUDPiece.enabled = false;
            shadow.enabled = false;
            piece.enabled = false;
            platform01.enabled = false;
            platform02.enabled = false;
            platform03.enabled = false;
            platform04.enabled = false;
            gear.enabled = false;
            balance.enabled = false;
            elevator.enabled = false;
            doorElevator.enabled = false;
            //AudioManager.SetMasterVolume(lowVolume);
            //audioPlayer.StopMusic();
            audioPlayer.PlayMusic(1);
        }
        else
        {
            canvasPause.SetActive(false);
            //canvasGameplay.SetActive(true);
            canvasGameplay.GetComponent<HideMouse>().enabled = true;
            audioPlayer.PlaySFX(23, 1, Random.Range(0.9f, 1.1f));
            //Time.timeScale = 1;
            canMove = true;
            canJump = true;
            animHUD.enabled = true;
            animHUDPiece.enabled = true;
            shadow.enabled = true;
            piece.enabled = true;
            platform01.enabled = true;
            platform02.enabled = true;
            platform03.enabled = true;
            platform04.enabled = true;
            gear.enabled = true;
            balance.enabled = true;
            elevator.enabled = true;
            doorElevator.enabled = true;
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
            anim.SetBool("isClimbing", isLaddering);
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
        if(abilityCounter <= 0)
        {
            anim.SetTrigger("ability");
            animHUD.SetTrigger("Entrada");
            audioPlayer.PlaySFX(3, 1, Random.Range(0.9f, 1.1f));
            useAbility += 1;
            if(useAbility > 5) scoreAbility -= 50;
            //if(doAbility) return;
            if (numResults > 0)
            {
                Debug.Log("Ability");
                //doAbility = true;
                for (int i = 0; i < numResults; i++)
                {
                    if (results[i].gameObject.tag == "MetalBox")
                    {
                        Vector2 dir = results[i].transform.position - this.transform.position;
                        dir.Normalize();
                        results[i].GetComponent<Rigidbody2D>().AddForce(dir * abilityForce, ForceMode2D.Impulse);
                        audioPlayer.PlaySFX(2, 1, Random.Range(0.9f, 1.1f));
                    }
                    else if (results[i].gameObject.tag == "WoodBox")
                    {
                        results[i].GetComponent<BoxSwitcher>().Switch();
                        audioPlayer.PlaySFX(0, 1, Random.Range(0.9f, 1.1f));
                    }
                    /*
                    else if(results[i].gameObject.tag == "CrashedWoodBox")
                    {
                        Vector2 dir = results[i].transform.position - this.transform.position;
                        dir.Normalize();
                        //results[i].gameObject.SetActive(true);
                        results[i].GetComponent<Rigidbody2D>().AddForce(dir * abilityForce, ForceMode2D.Impulse);
                    }
                    */
                }
            }
            abilityCounter = 400;
            animHUD.SetBool("Active", false);
        }
    }

    public void ReceiveDamage()
    {
        if(coolDown <= 0)
        {
            anim.SetTrigger("damage");
            animHeart1.SetBool("Damage", true);
            audioPlayer.PlaySFX(19, 1, Random.Range(0.9f, 1.1f));
            scoreLife = 150;
            coolDown = 3;

            life -= damage;
            if(life == 1)
            {
                animHeart2.SetBool("Damage", true);
                scoreLife = 75;
            }

            if (life <= 0)
            {
                life = 0;
                anim.SetBool("dead", true);
                animHeart3.SetBool("Damage", true);
                state = State.Dead;
            }
        }
    }
    
    public void LiquidPositive()
    {
		audioPlayer.PlaySFX(20, 1, Random.Range(0.9f, 1.1f));
        anim.SetTrigger("oilwalk");
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
		audioPlayer.PlaySFX(22, 1, Random.Range(0.9f, 1.1f));
        anim.SetTrigger("petrolwalk");
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
