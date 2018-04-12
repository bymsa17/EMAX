using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceTrigger : MonoBehaviour
{
    public GameObject piece;
    public Animator animHUD;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            animHUD.SetBool("piece", true);
            piece.SetActive(false);
        }
    }
}
