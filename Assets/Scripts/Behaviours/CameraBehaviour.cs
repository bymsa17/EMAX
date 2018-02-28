using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform target;
    public float smoothTime;
    private Vector3 velocity = Vector3.zero;
    public Vector3 offset;
    public bool isActive;

    public PlayerBehaviour player;

    private void Start()
    {
        transform.position = player.transform.position;
        isActive = false;
    }

    void FixedUpdate()
    {
        if(player.isFacingRight) offset.x = Mathf.Abs(offset.x);
        else offset.x = -Mathf.Abs(offset.x);

        Vector3 newPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);

        if(isActive == true)
        {
            CameraZoom();
        }
    }

    public void CameraZoom()
    {
        Camera.main.orthographicSize += smoothTime;
        offset.y = Mathf.Abs(7);
        if (Camera.main.orthographicSize >= 9.5f)
        {
            Camera.main.orthographicSize = 9.5f;
        }
    }
}
