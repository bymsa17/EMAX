using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour {

    #region Variables
    [Header("Physics")]
    private Rigidbody2D rb;
    private Collider2D coll;
    //private float gravityMagnitude = 1.50f;
    [Header("Permissions")]
    public bool checkGround = true;
    public bool checkCeiling = true;
    public bool checkWall = true;
    [Header("State")]
    public bool isGrounded;
    public bool isTouchingCeiling;
    public bool isTouchingWall;
    public bool isFalling;
    public bool wasGroundedLastFrame;
    public bool wasTouchingCeilingLastFrame;
    public bool WasTpuchingWallLastFrame;
    public bool justGotGrounded;
    public bool justNotGrounded;
    public bool justTouchWall;
    public bool justTpuchCeiling;
    [Header("Ground Filter")]
    public ContactFilter2D groundFilter;
    public ContactFilter2D wallFilter;
    public int maxGroundHits;
    //private LayerMask _groundMaskSave;
    [Header("Ground Box")]
    public Vector2 bottomBoxSize;
    public Vector2 bottomBoxPos;
    [Header("Ceiling Box")]
    public Vector2 topBoxSize;
    public Vector2 topBoxPos;
    [Header("Wall Box")]
    public Vector2 sideBoxSize;
    public Vector2 sideBoxPos;
    #endregion

    public void MyStart()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    public void MyFixedUpdate()
    {
        ResetState();

        if(checkGround) GroundCollision();
        //if(checkCeiling) CeilingCollision();
        //if(checkWall) WallCollision();
    }

    private void ResetState()
    {
        wasGroundedLastFrame = isGrounded;
        isGrounded = false;
        justNotGrounded = false;
        justGotGrounded = false;
        isFalling = true;
    }

    private void GroundCollision()
    {
        Collider2D[] results = new Collider2D[maxGroundHits];
        Vector2 pos = this.transform.position;
        int hits = Physics2D.OverlapBox(pos + bottomBoxPos, bottomBoxSize, 0, groundFilter, results);

        if (hits > 0)
        {
            isGrounded = true;
        }

        if(isGrounded) isFalling = false;
        if(!wasGroundedLastFrame && isGrounded) justGotGrounded = true;
        if(wasGroundedLastFrame && !isGrounded) justNotGrounded = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector2 pos = this.transform.position;
        Gizmos.DrawWireCube(pos + bottomBoxPos, bottomBoxSize);
    }
}
