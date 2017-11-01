using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour {

    [Header("State")]
    public bool isGrounded;
    public bool wasGroundedLastFrame;
    public bool justGrounded;
    public bool justNOTGrounded;
    public bool isFalling;

    [Header("Boxes")]
    public Vector2 groundBoxPos;
    public Vector2 groundBoxSize;

    [Header("Properties")]
    public int maxHits = 1;
    public bool detectGround = true;
    public ContactFilter2D filter;

    public void MyStart()
    {

    }

    public void MyFixedUpdate()
    {
        ResetState();
        DetectGround();
    }

    void ResetState()
    {
        wasGroundedLastFrame = isGrounded;
        isGrounded = false;
        justNOTGrounded = false;
        justGrounded = false;
        isFalling = true;
    }

    void DetectGround()
    {
        if (!detectGround) return;

        Collider2D[] results = new Collider2D[maxHits];
        Vector3 newPos = (Vector3)groundBoxPos + transform.position;
        int numHits = Physics2D.OverlapBox(newPos, groundBoxSize, 0, filter, results);

        if (numHits > 0)
        {
            isGrounded = true;
        }
        isFalling = !isGrounded;

        if (!wasGroundedLastFrame && isGrounded)
        {
            Debug.Log("JUST GROUNDED");
            justGrounded = true;
        }
        if (wasGroundedLastFrame && !isGrounded)
        {
            Debug.Log("JUST NOT GROUNDED");
            justNOTGrounded = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 newPos = (Vector3)groundBoxPos + transform.position;
        Gizmos.DrawWireCube(newPos, groundBoxSize);
    }
}
