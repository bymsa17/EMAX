using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public DoorBehaviour door;
    public CameraBehaviour mainCamera;
    public AudioPlayer audioPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("DoorTrigger");
            door.active = true;
            mainCamera.balanceOutActive = false;
            mainCamera.puzzleActive = true;
            audioPlayer.PlaySFX(25, 1, Random.Range(0.9f, 1.1f));
        }
    }
}
