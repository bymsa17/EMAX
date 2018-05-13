using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPuzzleBehaviour : MonoBehaviour
{
    public DoorBehaviour door;
    public bool active;
    public int counter;
    public int sequence;
    public FinalPuzzleTrigger buttonPressed01;
    public FinalPuzzleTrigger buttonPressed02;
    public FinalPuzzleTrigger buttonPressed03;
    public FinalPuzzleTrigger buttonPressed04;
    public Animator animButton01;
    public Animator animButton02;
    public Animator animButton03;
    public Animator animButton04;

    void Start ()
    {
        active = false;
        counter = 1;
    }

    public void TouchedButton(int button)
    {
        if(button == counter)
        {
            if(button == 4)
            {
                door.active = true;
            }
            else
            {
                counter++;
                animButton02.SetBool("Pressed", true);
            }
        }
        else
        {
            counter = 1;
            animButton02.SetBool("Pressed", false);
        }
    }
}
