using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilTrigger : MonoBehaviour
{
    private PlayerBehaviour player;
    //public float lostSpeed;
    public float counterTime;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("EnterPositivePlayer");
            player.LiquidPositive();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("ExitPositivePlayer");

            player.lostSpeed = true;

            /*if (player.walkSpeed <= 5)
            {
                player.walkSpeed = 5;
            }
            if (player.walkSpeed <= 7)
            {
                player.runSpeed = 7;
            }*/
        }
    }
}
