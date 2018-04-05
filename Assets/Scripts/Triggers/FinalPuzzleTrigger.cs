using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPuzzleTrigger : MonoBehaviour
{
    public FinalPuzzleBehaviour puzzle;
    public bool isActive;
    public int buttonNumber;

    void Start()
    {
        puzzle = GetComponentInParent<FinalPuzzleBehaviour>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("PuzzleTrigger");
            isActive = true;
            puzzle.TouchedButton(buttonNumber);
            //puzzle.active = true;
        }
    }
}
