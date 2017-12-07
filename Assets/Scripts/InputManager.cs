using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerBehaviour player;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
    }
	
	void Update ()
    {
        InputAxis();
        InputJump();
        InputRun();
        //InputAbility();
        InputPause();
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
    /*void InputAbility()
    {
        if(Input.GetButton("Ability"))
        {
            Debug.Log("Ability");
            player.Ability();
        }
    }*/
    void InputPause()
    {
        if(Input.GetButtonDown("Pause"))
        {
            Debug.Log("Pause");
            // Pausar el juego
        }
    }
}
