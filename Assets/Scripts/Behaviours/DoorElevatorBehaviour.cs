using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorElevatorBehaviour : MonoBehaviour
{
    public GameObject iniDoorL;
    public GameObject iniDoorR;
    public GameObject secDoorL;
    public GameObject secDoorR;
    public float timeCounter;
    public bool isActive;

    public Animator animDoorL;
    public Animator animDoorR;

    void Update ()
    {
        if(isActive == true) timeCounter++;

        if(timeCounter >= 50)
        {
            iniDoorL.SetActive(false);
            iniDoorR.SetActive(false);
            secDoorL.SetActive(true);
            secDoorR.SetActive(true);

            animDoorL.SetBool("CloseDoor", true);
            animDoorR.SetBool("CloseDoor", true);
        }
	}
}
