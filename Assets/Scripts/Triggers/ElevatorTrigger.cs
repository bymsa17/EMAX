﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    public DoorElevatorBehaviour door;
    public Animator animElevator;
    public Animator animDoorL;
    public Animator animDoorR;

	public AudioPlayer audioPlayer;
	//private AudioPlayer audioPlayer;

	void Start()
	{
		//audioPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
			
            Debug.Log("ElevatorTrigger");
            //elevator.activeDown = true;

            door.isActive = true;
            animElevator.SetTrigger("UpElevator");
            animDoorL.SetBool("OpenDoor", true);
            animDoorR.SetBool("OpenDoor", true);
			audioPlayer.PlaySFX(10, 1, Random.Range(0.9f, 1.1f));
        }
    }
}
