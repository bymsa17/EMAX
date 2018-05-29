using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public DoorBehaviour door;
    public CameraBehaviour mainCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("DoorTrigger");
            door.active = true;
            mainCamera.balanceOutActive = false;
            mainCamera.puzzleActive = true;
        }
    }
}
