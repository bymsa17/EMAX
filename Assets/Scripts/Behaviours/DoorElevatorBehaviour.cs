using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorElevatorBehaviour : MonoBehaviour
{
    public GameObject iniDoorL;
    public GameObject iniDoorR;
    public GameObject secDoorL;
    public GameObject secDoorR;
    public GameObject finalDoorL;
    public GameObject finalDoorR;

    public float timeCounter;
    public bool isActive;

    public Animator animSecDoorL;
    public Animator animSecDoorR;
    public Animator animFinalDoorL;
    public Animator animFinalDoorR;

    void Update ()
    {
        if(isActive == true) timeCounter++;

        if(timeCounter >= 50)
        {
            iniDoorL.SetActive(false);
            iniDoorR.SetActive(false);
            secDoorL.SetActive(true);
            secDoorR.SetActive(true);
            
            animSecDoorL.SetBool("CloseDoor", true);
            animSecDoorR.SetBool("CloseDoor", true);
        }

        if(timeCounter >= 280)
        {
            animSecDoorL.SetBool("OpenDoor", true);
            animSecDoorR.SetBool("OpenDoor", true);

            secDoorL.SetActive(false);
            secDoorR.SetActive(false);
            finalDoorL.SetActive(true);
            finalDoorR.SetActive(true);
        }
	}
}
