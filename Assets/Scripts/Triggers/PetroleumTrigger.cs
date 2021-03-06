﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetroleumTrigger : MonoBehaviour
{
    private PlayerBehaviour player;

    public Animator anim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //anim.SetTrigger("petrolwalk");
            anim.SetBool("petrol", true);
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
