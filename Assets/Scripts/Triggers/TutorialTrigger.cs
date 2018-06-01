using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public GameObject Text;
    public AudioPlayer audioPlayer;

    private void Start()
    {
        Text.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") Text.SetActive(true);
        audioPlayer.PlaySFX(27, 1, Random.Range(0.9f, 1.1f));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player") Text.SetActive(false);
        audioPlayer.PlaySFX(27, 1, Random.Range(0.9f, 1.1f));
    }
}
