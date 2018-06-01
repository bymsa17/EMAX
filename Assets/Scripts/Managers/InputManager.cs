using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class InputManager : MonoBehaviour
{
    //private LevelManager manager;
    private PlayerBehaviour player;
    //private BoxBehaviour metalBox;
    //private BoxBehaviour woodBox;
    public Transform canvasPause;
    public GameObject canvasGameplay;

    private AudioPlayer audioPlayer;

    /*
    public int backScene;
    public int currentScene;
    public int nextScene;
    public int logoScene = 1;
    public int titleScene = 2;
    */
    void Start ()
    {
        //AudioManager.Initialize();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();

        audioPlayer = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<AudioPlayer>();

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
        //InputLevelManager();
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
            player.Pause();        
        }
    }
    void InputGod()
    {
        if(Input.GetKeyDown(KeyCode.F10))
        {
            Debug.Log("GOD");
            player.SetGod();
            //manager.Update();
            //InputLevelManager();
        }
    }
    /*void InputLevelManager()
    {
        if(Input.GetKey(KeyCode.AltGr))
        {
            if(Input.GetKeyDown(KeyCode.N)) manager.LoadNext();
            if(Input.GetKeyDown(KeyCode.B)) manager.StartLoad(backScene);
            if(Input.GetKeyDown(KeyCode.L)) manager.StartLoad(logoScene);
            if(Input.GetKeyDown(KeyCode.M)) manager.StartLoad(titleScene);
            if(Input.GetKeyDown(KeyCode.R)) manager.StartLoad(currentScene);
        }
    }*/
}
