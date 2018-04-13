using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceTrigger : MonoBehaviour
{
    public GameObject piece;
    public Animator animHUD;
    public AudioPlayer audioPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            animHUD.SetBool("piece", true);
            audioPlayer.PlaySFX(7, 1, Random.Range(0.9f, 1.1f));
            piece.SetActive(false);
        }
    }
}
