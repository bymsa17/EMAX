using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform target;
    public float smoothTime;
    public float smoothOffset;
    private Vector3 velocity = Vector3.zero;
    public Vector3 offset;
    public bool puzzleActive;
    public bool balanceInActive;
    public bool balanceOutActive;

    public PlayerBehaviour player;

    private void Start()
    {
        transform.position = player.transform.position;
        puzzleActive = false;
        balanceInActive = false;
        balanceOutActive = false;
    }

    void FixedUpdate()
    {
        if(player.isFacingRight) offset.x = Mathf.Abs(offset.x);
        else offset.x = -Mathf.Abs(offset.x);

        Vector3 newPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);

        if(puzzleActive == true) PuzzleZoom();

        if(balanceInActive == true) BalanceZoomIn();
        if(balanceOutActive == true) BalanceZoomOut();

    }

    public void PuzzleZoom()
    {
        smoothTime -= 0.01f;
        if (smoothTime <= 0.20f) smoothTime = 0.20f;
        smoothOffset -= 0.025f;
        if (smoothOffset <= 0) smoothOffset = 0;
        Camera.main.orthographicSize += smoothTime;
        offset.y += smoothOffset;
        if (Camera.main.orthographicSize >= 6)
        {
            Camera.main.orthographicSize = 6;
        }
    }

    public void BalanceZoomIn()
    {
        smoothTime -= 0.01f;
        if(smoothTime <= 0.20f) smoothTime = 0.20f;
        //smoothOffset -= 0.025f;
        //if(smoothOffset <= 0) smoothOffset = 0;
        Camera.main.orthographicSize += smoothTime;
        //offset.y += smoothOffset;
        if(Camera.main.orthographicSize >= 5)
        {
            Camera.main.orthographicSize = 5;
        }
    }

    public void BalanceZoomOut()
    {
        smoothTime -= 0.01f;
        if(smoothTime <= 0.20f) smoothTime = 0.20f;
        //smoothOffset -= 0.025f;
        //if(smoothOffset <= 0) smoothOffset = 0;
        Camera.main.orthographicSize += smoothTime;
        //offset.y += smoothOffset;
        if(Camera.main.orthographicSize >= 3)
        {
            Camera.main.orthographicSize = 3;
        }
    }
}
