﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    public ElevatorBehaviour elevator;
    public Animator animElevator;
    public Animator animDoorL;
    public Animator animDoorR;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("ElevatorTrigger");
            //elevator.activeDown = true;
            animElevator.SetTrigger("UpElevator");
            animDoorL.SetBool("OpenDoor", true);
            animDoorR.SetBool("OpenDoor", true);
        }
    }
}
