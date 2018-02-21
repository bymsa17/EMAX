using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform target;
    public float smoothTime;
    private Vector3 velocity = Vector3.zero;
    public Vector3 offset;

    public PlayerBehaviour player;

    private void Start()
    {
        transform.position = player.transform.position;
    }

    void FixedUpdate()
    {
        if(player.isFacingRight) offset.x = Mathf.Abs(offset.x);
        else offset.x = -Mathf.Abs(offset.x);

        Vector3 newPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }
}
