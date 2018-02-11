﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class InputManager : MonoBehaviour
{
    private PlayerBehaviour player;
    private BoxBehaviour metalBox;
    private BoxBehaviour woodBox;
    public Transform canvasPause;

    void Start ()
    {
        AudioManager.Initialize();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();

        //metalBox = GameObject.FindGameObjectWithTag("MetalBox").GetComponent<BoxBehaviour>();
        //woodBox = GameObject.FindGameObjectWithTag("WoodBox").GetComponent<BoxBehaviour>();
    }
	
	void Update ()
    {
        InputAxis();
        InputJump();
        InputRun();
        InputAbility();
        InputPause();
        InputGod();
    }

    void InputAxis()
    {
        Vector2 axis = Vector2.zero;
        axis.x = Input.GetAxis("Horizontal");
        axis.y = Input.GetAxis("Vertical");
        // TODO: Le pasamos el axis al player
        player.SetAxis(axis);
    }
    void InputJump()
    {
        if(Input.GetButton("Jump"))
        {
            Debug.Log("Jump");
            // TODO: darle la orden al player de saltar
            player.JumpStart();
        }
    }
    void InputRun()
    {
        if(Input.GetButtonDown("Run"))
        {
            Debug.Log("Run");
            // TODO: darle la orden al player de correr
            player.isRunning = true;
        }
        if(Input.GetButtonUp("Run"))
        {
            Debug.Log("Walk");
            // TODO: darle la orden al player de caminar
            player.isRunning = false;
        }
    }
    void InputAbility()
    {
        if(Input.GetButtonDown("Ability"))
        {
            player.Ability();
            
            //metalBox.Ability();
            //woodBox.Ability();
        }
    }
    void InputPause()
    {
        if(Input.GetButtonDown("Pause"))
        {
            Debug.Log("Pause");
            // Pausar el juego
            if(canvasPause.gameObject.activeInHierarchy == false)
            {
                canvasPause.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                canvasPause.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
    void InputGod()
    {
        if(Input.GetKeyDown(KeyCode.F10))
        {
            Debug.Log("GOD");
            player.SetGod();
        }
    }
}
