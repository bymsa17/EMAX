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

    public AudioPlayer audioPlayer;

    void Start ()
    {
        active = false;
        counter = 1;
    }

    public void TouchedButton(int button)
    {
        if(button == counter)
        {
            audioPlayer.PlaySFX(9, 1, Random.Range(0.9f, 1.1f));
            if (button == 1) animButton01.SetBool("Pressed", true);
            else if(button == 2) animButton02.SetBool("Pressed", true);
            else if(button == 3) animButton03.SetBool("Pressed", true);
            if(button == 4)
            {
                animButton04.SetBool("Pressed", true);
                door.active = true;
            }
            else counter++;
        }
        else
        {
            audioPlayer.PlaySFX(8, 1, Random.Range(0.9f, 1.1f));
            counter = 1;
            animButton01.SetBool("Pressed", false);
            animButton02.SetBool("Pressed", false);
            animButton03.SetBool("Pressed", false);
            animButton04.SetBool("Pressed", false);
        }
    }
}
