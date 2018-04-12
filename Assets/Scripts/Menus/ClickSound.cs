using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    public AudioSource audioButton;

    public void SelectSound()
    {
        audioButton.Play();
    }
}
