using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPuzzleTrigger : MonoBehaviour
{
    public FinalPuzzleBehaviour puzzle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("PuzzleTrigger");
            puzzle.active = true;
        }
    }
}
