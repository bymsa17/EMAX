using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPuzzleBehaviour : MonoBehaviour
{
    public bool active;
    public bool buttonPressed01;
    public bool buttonPressed02;
    public bool buttonPressed03;
    public bool buttonPressed04;

    void Start ()
    {
        active = false;
    }
	
	void Update ()
    {
        if(active)
        {
            UpDoor();
        }
    }

    void UpDoor()
    {
        
    }
}
