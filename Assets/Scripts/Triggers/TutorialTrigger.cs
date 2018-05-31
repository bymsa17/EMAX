using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public GameObject Text;

    private void Start()
    {
        Text.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") Text.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player") Text.SetActive(false);
    }
}
