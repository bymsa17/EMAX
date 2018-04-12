using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    private AudioPlayer audioPlayer;

    void Start()
    {
        audioPlayer = GetComponentInChildren<AudioPlayer>();
    }

    public void SelectSound()
    {
        audioPlayer.PlaySFX(7, 1, Random.Range(0.9f, 1.1f));
    }
}
