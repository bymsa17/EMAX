using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetroleumTrigger : MonoBehaviour
{
    private PlayerBehaviour player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("EnterNegativePlayer");
            player.LiquidNegative();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("ExitNegativePlayer");
            player.walkSpeed = 5;
            player.runSpeed = 7;
        }
    }
}
